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
            this._furnanceWidth = furnanceWidth;
        }
    }
}