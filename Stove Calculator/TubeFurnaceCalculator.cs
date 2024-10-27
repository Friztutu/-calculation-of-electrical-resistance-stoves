using Syncfusion.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator
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
            this.stoveDiameter = diameter;
            this.stoveLength = length;
            this.maximumSampleTemperature = sampleTemp;
            this.ambientGasTemperature = gasTemp;
            this.outerSurfaceTemperature = surfaceTemp;
        }
    }
}
