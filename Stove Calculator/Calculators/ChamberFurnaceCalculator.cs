using Stove_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stove_Calculator.Constans;

namespace Stove_Calculator.Calculators
{
    public class ChamberFurnaceCalculator
    {
        public static double CalculateLiningFireproofSurfaceTemperature(
            Fireproof liningFireproof, double liningFireproofWidth, double ambientTemperatur, double outerSurfaceTemperature, double maxSampleTemperature)
        {
            double liningFireproofSurfaceTemperature;

            double y1 = Constant.I + Constant.J * outerSurfaceTemperature;
            double q1 = y1 * (outerSurfaceTemperature - ambientTemperatur);

            double sqrtExpression = Math.Pow(2 * liningFireproof.AValue, 2) - 4 * liningFireproof.BValue *
                (2 * liningFireproofWidth * q1 - 2 * liningFireproof.AValue * maxSampleTemperature - liningFireproof.BValue * Math.Pow(maxSampleTemperature, 2));

            liningFireproofSurfaceTemperature = (-2 * liningFireproof.AValue + Math.Sqrt(sqrtExpression)) / (2 * liningFireproof.BValue);

            return liningFireproofSurfaceTemperature;
        }

        public static double CalculateInsulationWidth(
            ThermalInsulation liningInsulation, double liningFireproofSurfaceTemperature, double outerSurfaceTemperature, double ambientGasTemperature)
        {
            double liningInsulationWidth;

            double x2 = liningInsulation.AValue + (liningInsulation.BValue * ((liningFireproofSurfaceTemperature + outerSurfaceTemperature) / 2));
            double y1 = Constant.I + Constant.J * outerSurfaceTemperature;
            double q1 = y1 * (outerSurfaceTemperature - ambientGasTemperature);

            liningInsulationWidth = (x2 * (liningFireproofSurfaceTemperature - outerSurfaceTemperature) / q1);

            return liningInsulationWidth;
        }
    }
}
