using Gnostice.Documents.PDF;
using SkiaSharp;
using Stove_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using RSAExtensions;
using System.Runtime.Intrinsics.X86;

namespace Stove_Calculator.Calculators
{
    public class ChamberFurnaceCalculator
    {
        private double stoveHeight;
        private double stoveWidth;
        private double stoveLength;
        private double maximumSampleTemperature;
        private double ambientGasTemperature;
        private double outerSurfaceTemperature;

        private double maxTemperatureHeater;
        private double temperatureInSurfaceFireproof;

        public readonly ImmutableList<Fireproof> fireproofs;
        private Fireproof selectedFireproof;
        private double fireproofWidth;

        public Fireproof SelectedFireproof
        {
            get
            {
                return selectedFireproof;
            }

            set
            {
                selectedFireproof = value;
                fireproofWidth = CalculateFurnaceLining();
            }
        }

        public double FireproofWidth
        {
            get { return fireproofWidth; }
        }

        private double y1;

        public ChamberFurnaceCalculator(double height, double width, double length,
            double sampleTemp, double gasTemp, double surfaceTemp)
        {
            this. stoveWidth = width;
            this.stoveHeight = height;
            this.stoveLength = length;
            this.maximumSampleTemperature = sampleTemp;
            this.ambientGasTemperature = gasTemp;
            this.outerSurfaceTemperature = surfaceTemp;

            this.maxTemperatureHeater = sampleTemp + 100;
            this.temperatureInSurfaceFireproof = sampleTemp + 100;

            fireproofs = GetSuitableFireproofs();
            SelectedFireproof = fireproofs.First();
        }

        private ImmutableList<Fireproof> GetSuitableFireproofs()
        {
            ImmutableList<Fireproof> query;

            using (var context = new FireproofContext())
            {
                var blogs = from b in context.Fireproof
                            where b.MaxTemperatureOfUse >= this.maxTemperatureHeater
                            orderby b.MaxTemperatureOfUse, b.Density descending,
                            b.AValue + b.BValue * this.maximumSampleTemperature
                            select b;

                query = blogs.ToImmutableList();

                return query;
            }
        }

        private double CalculateFurnaceLining()
        {
            double y1 = 9.304 + 0.05815 * outerSurfaceTemperature;
            double q1 = y1 * (outerSurfaceTemperature - ambientGasTemperature);

            double width = 0;
            double t2 = 2000;

            do
            {
                width += 0.001;
                double sqrtExp = Math.Pow(2 * selectedFireproof.AValue, 2) - 4 * selectedFireproof.BValue *
                    (2 * width * q1 - 2 * selectedFireproof.AValue * maxTemperatureHeater - selectedFireproof.BValue * Math.Pow(maxTemperatureHeater, 2));
                t2 = (-2 * selectedFireproof.AValue + Math.Sqrt(sqrtExp)) / (2 * selectedFireproof.BValue);
                //MessageBox.Show($"a1 = {selectedFireproof.AValue}\nb1 = {selectedFireproof.BValue}\nt2 = {t2}");
            } while (t2 > 1100);

            return width;
        }
    }
}
