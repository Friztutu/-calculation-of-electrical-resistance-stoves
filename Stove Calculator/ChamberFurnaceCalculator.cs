using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator
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
            this.stoveWidth = width;
            this.stoveHeight = height;
            this.stoveLength = length;
            this.maximumSampleTemperature = sampleTemp;
            this.ambientGasTemperature = gasTemp; 
            this.outerSurfaceTemperature = surfaceTemp;
        }
    }
}
