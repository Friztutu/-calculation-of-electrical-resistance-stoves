using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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

        public ChamberFurnaceCalculator(double height, double width, double length,
            double sampleTemp, double gasTemp, double surfaceTemp)
        {
            stoveWidth = width;
            stoveHeight = height;
            stoveLength = length;
            maximumSampleTemperature = sampleTemp;
            ambientGasTemperature = gasTemp;
            outerSurfaceTemperature = surfaceTemp;
        }
    }
}
