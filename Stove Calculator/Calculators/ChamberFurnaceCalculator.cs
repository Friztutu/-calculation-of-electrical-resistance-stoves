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

            fireproofs = getSuitableFireproofs();
            selectedFireproof = fireproofs.First();

            y1 = selectedFireproof.AValue + (selectedFireproof.BValue * (ambientGasTemperature + outerSurfaceTemperature) / 2);
        }

        private ImmutableList<Fireproof> getSuitableFireproofs()
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
    }
}
