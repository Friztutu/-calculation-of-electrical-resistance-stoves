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
            double maxSampleTemperature, double ambientGasTemperature, double outerSurfaceTemperature, double fireproofWidth,
            bool isWithDoor, bool isDoubleLayer) 
            : base(furnanceLength, maxSampleTemperature, ambientGasTemperature, outerSurfaceTemperature, fireproofWidth, isWithDoor, isDoubleLayer) 
        {
            this._furnanceHeight = furnanceHeight;
            this._furnanceWidth = furnanceWidth;

            this._liningFireproof = FireproofAnalyzer.GetSuitableLiningFireproofs(_maxSampleTemperature)[0];
            CalculateFireprooSurfaceTemperature();

            if(_liningFireproofSurfaceTemperature <= 1100)
            {
                this._liningInsulation = ThermalInsulationAnalyzer.GetSuitableLiningThermalInsulation(_liningFireproofSurfaceTemperature, _maxSampleTemperature)[0];
                CalculateInsulationWidth();
                this._overlapFireproof = FireproofAnalyzer.GetSuitableOverlapFireproofs(_maxSampleTemperature)[0];
                this._overlapFireproofWidth = 0;

                if(isDoubleLayer)
                {
                    this._overlapInsulation = ThermalInsulationAnalyzer.GetSuitableOverlapThermalInsulation(this._maxSampleTemperature)[0];
                }

                CalculateOverlapSurfaceTemperature();
            } 
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