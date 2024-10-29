using Syncfusion.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Calculators
{
    public class TubeFurnaceCalculator
    {
        private double stoveDiameter;
        private double stoveLength;
        private double maximumSampleTemperature;
        private double ambientGasTemperature;
        private double outerSurfaceTemperature;

        public TubeFurnaceCalculator(double diameter, double length,
            double sampleTemp, double gasTemp, double surfaceTemp)
        {
            stoveDiameter = diameter;
            stoveLength = length;
            maximumSampleTemperature = sampleTemp;
            ambientGasTemperature = gasTemp;
            outerSurfaceTemperature = surfaceTemp;
        }
    }
}
