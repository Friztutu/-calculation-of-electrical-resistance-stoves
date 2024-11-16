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
        // Dimensions
        protected readonly double _furnanceHeight;
        protected readonly double _furnanceWidth;

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
            this._furnanceWidth = furnanceWidth;
        }

        protected override void CalculateLiningFireproofSurfaceTemperature()
        {
            double y1 = Constant.I + Constant.J * _outerSurfaceTemperature;
            double q1 = y1 * (_outerSurfaceTemperature - _ambientGasTemperature);

            double sqrtExpression = Math.Pow(2 * _liningFireproof.AValue, 2) - 4 * _liningFireproof.BValue *
                (2 * _liningFireproofWidth * q1 - 2 * _liningFireproof.AValue * _workTemperature - _liningFireproof.BValue * 
                Math.Pow(_workTemperature, 2));

            _liningFireproofSurfaceTemperature = (-2 * _liningFireproof.AValue + Math.Sqrt(sqrtExpression)) / (2 * _liningFireproof.BValue);
        }

        protected override void CalculateInsulationWidth()
        {
            double x2 = _liningInsulation.AValue + (_liningInsulation.BValue * ((_liningFireproofSurfaceTemperature + _outerSurfaceTemperature) / 2));
            double y1 = Constant.I + Constant.J * _outerSurfaceTemperature;
            double q1 = y1 * (_outerSurfaceTemperature - _ambientGasTemperature);

            _liningInsulationWidth = (x2 * (_liningFireproofSurfaceTemperature - _outerSurfaceTemperature) / q1);
        }
    }
}
