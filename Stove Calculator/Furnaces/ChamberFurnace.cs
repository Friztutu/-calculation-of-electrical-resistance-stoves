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
using Stove_Calculator.Furnaces;
using Stove_Calculator.Analyzers;
using System.Windows.Media.Animation;
using Stove_Calculator.Constans;

namespace Stove_Calculator.Calculators
{
    public class ChamberFurnace : Furnace
    {
        public unsafe static double CalculateLiningFireproofSurfaceTemperature(
            Fireproof liningFireproof, double outerSurfaceTemperature,
            double ambientGasTemperature, double workTemperature,
            double liningFireproofWidth, double* x1)
        {
            double y1 = Constant.I + Constant.J * outerSurfaceTemperature;
            double q1 = y1 * (outerSurfaceTemperature - ambientGasTemperature);

            double sqrtExpression = Math.Pow(2 * liningFireproof.AValue, 2) - 4 * liningFireproof.BValue *
                (2 * liningFireproofWidth * q1 - 2 * liningFireproof.AValue * workTemperature - liningFireproof.BValue * 
                Math.Pow(workTemperature, 2));

            double liningFireproofSurfaceTemperature = (-2 * liningFireproof.AValue + Math.Sqrt(sqrtExpression)) / (2 * liningFireproof.BValue);
            *x1 = liningFireproof.AValue + (liningFireproof.BValue * (workTemperature + liningFireproofSurfaceTemperature) / 2);

            return liningFireproofSurfaceTemperature;        
        }

        public static double CalculateInsulationWidth(
            ThermalInsulation liningInsulation, double liningFireproofSurfaceTemperature,
            double outerSurfaceTempearature, double ambientGasTemperature)
        {
            double x2 = liningInsulation.AValue + (liningInsulation.BValue * ((liningFireproofSurfaceTemperature + outerSurfaceTempearature) / 2));
            double y1 = Constant.I + Constant.J * outerSurfaceTempearature;
            double q1 = y1 * (outerSurfaceTempearature - ambientGasTemperature);

            double liningInsulationWidth = (x2 * (liningFireproofSurfaceTemperature - outerSurfaceTempearature) / q1);

            return liningInsulationWidth;
        }

        public unsafe static void CalculateParameters(
            bool isDoor, bool isDoubleLayer, double furnaceHeight,
            double furnaceWidth, double furnaceLength, double overlapFireproofWidth,
            double overlapInsulationWidth, double liningFireproofWidth, double liningInsulationWidth
            )
        {
             
        }
    }
}
