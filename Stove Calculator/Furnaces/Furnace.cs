using Stove_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stove_Calculator.Analyzers;
using System.Windows.Media.Animation;

namespace Stove_Calculator.Furnaces
{
    public abstract class Furnace
    {
        // Dimensions
        protected readonly double _furnanceLength;

        // Temperature parameters
        protected readonly double _maxSampleTemperature;
        protected readonly double _ambientGasTemperature;
        protected readonly double _outerSurfaceTemperature;

        // Furnace overlap parameters
        protected readonly bool _isWithDoor;
        protected readonly bool _isDoubleLayer;
        protected Fireproof _overlapFireproof;
        protected double _overlapFireproofWidth;
        protected ThermalInsulation _overlapInsulation;
        protected double _overlapInsulationWidth;
        protected double _overlapFireproofSurfaceTemperature;

        // Lining parameters
        protected Fireproof _liningFireproof;
        protected double _liningFireproofWidth;
        protected double _liningFireproofSurfaceTemperature;
        protected ThermalInsulation _liningInsulation;
        protected double _liningInsulationWidth;

        // GETTERS
        public double FurnaceLength => _furnanceLength;
        public double MaxSampleTemperature => _maxSampleTemperature;
        public double AmbientGasTemperature => _ambientGasTemperature;
        public double OuterSurfaceTemperature => _outerSurfaceTemperature;
        public bool IsWithDoor => _isWithDoor;
        public bool IsDoubleLayer => _isDoubleLayer;

        public Furnace(
            double furnanceLength, double maxSampleTemperature, double ambientGasTemperature, double outerSurfaceTemperature,
            bool isWithDoor, bool isDoubleLayer
            )
        {
            this._furnanceLength = furnanceLength;
            this._maxSampleTemperature = maxSampleTemperature;
            this._ambientGasTemperature = ambientGasTemperature;
            this._outerSurfaceTemperature = outerSurfaceTemperature;
            this._isWithDoor = isWithDoor;
            this._isDoubleLayer = isDoubleLayer;
        }
    }
}
