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

namespace Stove_Calculator.Calculators
{
    public class ChamberFurnace : Furnace
    {
        // Dimensions
        private readonly double _furnanceHeight;
        private readonly double _furnanceWidth;

        // Getters
        public double FurnanceHeight => _furnanceHeight;
        public double FurnanceWidth => _furnanceWidth;
        
        public ChamberFurnace(
            double furnanceLength, double furnanceHeight, double furnanceWidth, 
            double maxSampleTemperature, double ambientGasTemperature, double outerSurfaceTemperature,
            bool isWithDoor, bool isDoubleLayer) 
            : base(furnanceLength, maxSampleTemperature, ambientGasTemperature, outerSurfaceTemperature, isWithDoor, isDoubleLayer) 
        {
            this._furnanceHeight = furnanceHeight;
        }
 
        protected override void CalculateFireprooSurfaceTemperature()
        {
            double y1 = 9.304 + 0.05815 * _outerSurfaceTemperature;
            double q1 = y1 * (_outerSurfaceTemperature - _ambientGasTemperature);

            double sqrtExpression = Math.Pow(2 * _liningFireproof.AValue, 2) - 4 * _liningFireproof.BValue * 
                (2 * _liningFireproofWidth * q1 - 2 * _liningFireproof.AValue * _maxSampleTemperature - _liningFireproof.BValue * Math.Pow(_maxSampleTemperature, 2));

            _liningFireproofSurfaceTemperature = (-2 * _liningFireproof.AValue + Math.Sqrt(sqrtExpression)) / (2 * _liningFireproof.BValue);
        }

        protected override void CalculateInsulationWidth()
        {
            double x2 = _liningInsulation.AValue + (_liningInsulation.BValue * ((_liningFireproofSurfaceTemperature + _outerSurfaceTemperature) / 2));
            double y1 = 9.304 + 0.05815 * _outerSurfaceTemperature;
            double q1 = y1 * (_outerSurfaceTemperature - _ambientGasTemperature);

            _liningInsulationWidth = (x2 * (_liningFireproofSurfaceTemperature - _outerSurfaceTemperature) / q1);
        }

        protected override void CalculateOverlapSurfaceTemperature()
        {
            if (IsDoubleLayer)
            {

                // TODO: переписать эту залупистику, я ебал, там формул и расчётов
                double t4, t5, t7, x3, q21, x4, y2, q22;
                bool isCorrect = false;

                t4 = 0;

                do
                {
                    t4++;
                    double firstBracket = (2 * (_overlapFireproof.BValue * _overlapInsulationWidth + _overlapInsulation.BValue * _overlapFireproofWidth));
                    double secondBracket = (2 * _overlapFireproof.AValue * _overlapInsulationWidth + 2 * _overlapInsulation.AValue * _overlapFireproofWidth);
                    double thirdBracket1 = 2 * _overlapFireproof.AValue * _overlapInsulationWidth * (_maxSampleTemperature + 100) +
                        _overlapFireproof.BValue + _overlapInsulationWidth * Math.Pow((_maxSampleTemperature + 100), 2);
                    double thirdBracket2 = 2 * _overlapInsulation.AValue * _overlapFireproofWidth * t4 +
                        _overlapInsulation.BValue + _overlapFireproofWidth * Math.Pow(t4, 2);

                    t5 = 1 / firstBracket * (-secondBracket + Math.Sqrt(Math.Pow(secondBracket, 2) + 2 * firstBracket * (thirdBracket1 + thirdBracket2)));

                    x3 = _overlapFireproof.AValue + (_overlapFireproof.BValue * ((_maxSampleTemperature + 100) + t5) / 2);
                    q21 = x3 * ((_maxSampleTemperature + 100) - t5) / _overlapFireproofWidth;
                    t7 = (-(0.05815 - 9.304 * _ambientGasTemperature) + Math.Sqrt(Math.Pow((0.05815 - 9.304 * _ambientGasTemperature), 2) + 4 * 0.05815 * (9.304 * _ambientGasTemperature + q21))) / (2 * 0.05815);
                } while (Math.Round(t4) == Math.Round(t7) || t4 > 600);

                x4 = _overlapInsulation.AValue + (_overlapInsulation.BValue * (t5 + (_maxSampleTemperature + 100)) / 2);
                y2 = 9.304 + 0.05815 * t4;
                q22 = (x4 * (t5 - t4)) / _liningInsulationWidth;
            }
            else
            {
                double firstBracket = 1 / (2 * (_overlapFireproof.BValue + 2 * _overlapFireproofWidth * 0.05815));
                double secondBracket = 2 * _overlapFireproof.AValue + 2 * _overlapFireproofWidth * 9.304 - 2 * _overlapFireproofWidth * 0.05815 * _ambientGasTemperature;
                double thirdBracket = 4 * (_overlapFireproof.BValue + 2 * _overlapFireproofWidth * 0.05815);
                double fourthBracket = 2 * _overlapFireproof.AValue * _maxSampleTemperature + _overlapFireproof.BValue * Math.Pow(_maxSampleTemperature, 2)
                    + 2 * _overlapFireproofWidth * 9.304 * _ambientGasTemperature;

                _overlapFireproofSurfaceTemperature = firstBracket * (-secondBracket + Math.Sqrt(Math.Pow(secondBracket, 2) + thirdBracket * fourthBracket));
            }
        }
    }
}