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
        private double fireproofSurfaceTemperature;

        public ImmutableList<ThermalInsulation> thermalInsulations;

        public Fireproof SelectedFireproof
        {
            get
            {
                return selectedFireproof;
            }

            set
            {
                selectedFireproof = value;
                CalculateFireproofSurfaceTemperature();
            }
        }
        public double FireproofWidth
        {
            get 
            { 
                return fireproofWidth; 
            }

            set 
            { 
                fireproofWidth = value;
                CalculateFireproofSurfaceTemperature();
            }
        }

        public double FireproofSurfaceTemperature
        {
            get 
            { 
                return fireproofSurfaceTemperature; 
            }

            set
            {
                fireproofSurfaceTemperature = value;
                CalculateFireproofWidth();
            }
        }

        public ChamberFurnaceCalculator(double height, double width, double length,
            double sampleTemp, double gasTemp, double surfaceTemp)
        {
            this.stoveWidth = width;
            this.stoveHeight = height;
            this.stoveLength = length;
            this.maximumSampleTemperature = sampleTemp;
            this.ambientGasTemperature = gasTemp;
            this.outerSurfaceTemperature = surfaceTemp;

            this.maxTemperatureHeater = sampleTemp + 100;
            this.temperatureInSurfaceFireproof = sampleTemp + 100;

            fireproofs = GetSuitableFireproofs();
            selectedFireproof = fireproofs.First();
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

        private ImmutableList<ThermalInsulation> GetSuitableThermalInsulation()
        {
            ImmutableList<ThermalInsulation> query;

            using (var context = new ThermalInsulationContext())
            {
                var blogs = from b in context.ThermalInsulation
                            where b.MaxTemperatureOfUse >= fireproofSurfaceTemperature
                            orderby b.MaxTemperatureOfUse, b.AValue + b.BValue * this.maximumSampleTemperature, b.Density descending
                            select b;

                query = blogs.ToImmutableList();
                return query;
            }
        }
 
        private void CalculateFireproofSurfaceTemperature()
        {
            double y1 = 9.304 + 0.05815 * outerSurfaceTemperature;
            double q1 = y1 * (outerSurfaceTemperature - ambientGasTemperature);

            double sqrtExpression = Math.Pow(2 * selectedFireproof.AValue, 2) - 4 * selectedFireproof.BValue * 
                (2 * fireproofWidth * q1 - 2 * selectedFireproof.AValue * maxTemperatureHeater - selectedFireproof.BValue * Math.Pow(maxTemperatureHeater, 2));

            fireproofSurfaceTemperature = (-2 * selectedFireproof.AValue + Math.Sqrt(sqrtExpression)) / (2 * selectedFireproof.BValue);

            thermalInsulations = GetSuitableThermalInsulation();
        }

        private void CalculateFireproofWidth()
        {
            double y1 = 9.304 + 0.05815 * outerSurfaceTemperature;
            double q1 = y1 * (outerSurfaceTemperature - ambientGasTemperature);

            double firstParenthesis = selectedFireproof.AValue + selectedFireproof.BValue * ((maxTemperatureHeater + fireproofSurfaceTemperature) / 2);
            double secondParenthesis = (maxTemperatureHeater -  fireproofSurfaceTemperature) / q1;

            fireproofWidth = firstParenthesis * secondParenthesis;
        }
    }
}
