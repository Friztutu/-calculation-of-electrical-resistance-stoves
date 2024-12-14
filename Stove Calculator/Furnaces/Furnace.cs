using Stove_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stove_Calculator.Analyzers;
using System.Windows.Media.Animation;
using System.Reflection.Metadata;
using Stove_Calculator.Constans;
using Constant = Stove_Calculator.Constans.Constant;
using SkiaSharp;
using Microsoft.EntityFrameworkCore;

namespace Stove_Calculator.Furnaces
{
    public abstract class Furnace
    {
        public static double CalculateOneLayerOverlapSurfaceTemperature(
            Fireproof overlapFireproof, double ambientGasTemperature, 
            double workTemperature, double overlapFireproofWidth)
        {
            double a3 = overlapFireproof.AValue;
            double b3 = overlapFireproof.BValue;
            double h3 = overlapFireproofWidth;
            double j = Constant.J;
            double i = Constant.I;
            double t0 = ambientGasTemperature;
            double t1 = workTemperature;

            double firstBracket = 2 * (b3 + 2 * h3 * j);
            double secondBracket = 2 * a3 + 2 * h3 * i - 2 * h3 * j * t0;
            double thirdBracket = 2 * a3 * t1 + b3 * Math.Pow(t1, 2) + 2 * h3 * i * t0;

            double overlapSurfaceFireproof = 1 / firstBracket * (-secondBracket + Math.Sqrt(Math.Pow(secondBracket, 2) + 2 * firstBracket * thirdBracket));
            return overlapSurfaceFireproof;
        }

        public static unsafe bool CalculateDoubleLayerOverlapSurfaceTemperature(
            Fireproof overlapFireproof, ThermalInsulation overlapInsulation, 
            double overlapInsulationWidth, double overlapFireproofWidth,
            double workTemperature, double ambientGasTemperature,
            double* overlapSurfaceTemperature, double* overlapLiningTemperature) 
        {
            bool status = true;

            double q2, x3, t5, tz;

            double i = Constant.I;
            double j = Constant.J;
            double a3 = overlapFireproof.AValue;
            double b3 = overlapFireproof.BValue;
            double a4 = overlapInsulation.AValue;
            double b4 = overlapInsulation.BValue;
            double h3 = overlapFireproofWidth;
            double h4 = overlapInsulationWidth;
            double t1 = workTemperature;
            double t0 = ambientGasTemperature;
            double t4 = ambientGasTemperature - 0.01;

            do
            {
                t4 += 0.1;

                double firstBracket = 2 * (b3 * h4 + b4 * h3);
                double secondBracket = 2 * a3 * h4 + 2 * a4 * h3;
                double thirdBracket = 2 * a3 * h4 * t1 + b3 * h4 * Math.Pow(t1, 2);
                double fouthBracket = 2 * a4 * h3 * t4 + b4 * h3 * Math.Pow(t4, 2);

                t5 = (1 / firstBracket) * (-secondBracket + Math.Sqrt(Math.Pow(secondBracket, 2) + 2 * firstBracket * (thirdBracket + fouthBracket)));

                x3 = a3 + (b3 * (t1 + t5) / 2);
                q2 = (x3 * (t1 - t5)) / h3;

                tz = (-(i - j * t0) + Math.Sqrt(Math.Pow(i - j * t0, 2) + 4 * j * (i * t0 + q2))) / (2 * j);

            } while (Math.Round(tz, 1) != Math.Round(t4, 1) && t4 < workTemperature);

            *overlapSurfaceTemperature = t5;
            *overlapLiningTemperature = t4;

            return status;
        }
    }
}
