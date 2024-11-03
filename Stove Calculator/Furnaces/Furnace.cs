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

        // Lining parameters
        protected Fireproof _liningFireproof;
        protected double _liningFireproofWidth;
        protected double _liningFireproofSurfaceTemperature;
        protected ThermalInsulation _liningInsulation;
        protected double _liningInsulationWidth;

        // GETTERS
        public double FurnanceLength => _furnanceLength;
        public double MaxSampleTemperature => _maxSampleTemperature;
        public double AmbientGasTemprerature => _ambientGasTemperature;
        public double OuterSurfaceTemperature => _outerSurfaceTemperature;
        public bool IsWithDoor => _isWithDoor;
        public bool IsDoubleLayer => _isDoubleLayer;
        public double LiningFireproofSurfaceTemperature => _liningFireproofSurfaceTemperature;
        public double LiningInsulationWidth => _liningInsulationWidth;


        public Fireproof LiningFireproof
        {
            get => _liningFireproof;

            set
            {
                _liningFireproof = value;
                CalculateFireprooSurfaceTemperature();

                if(_liningFireproofSurfaceTemperature <= 1100)
                {
                    _liningInsulation = (_liningInsulation is null) ?
                        ThermalInsulationAnalyzer.GetSuitableThermalInsulation(_liningFireproofSurfaceTemperature, _maxSampleTemperature)[0] : _liningInsulation;
                    CalculateInsulationWidth();
                }
                else
                {
                    _liningInsulation = null;
                    _liningInsulationWidth = 0;
                }
            }
        }

        public double LiningFireproofWidth
        {
            get => _liningFireproofWidth;

            set
            {
                _liningFireproofWidth = value;
                CalculateFireprooSurfaceTemperature();

                if(_liningFireproofSurfaceTemperature <= 1100)
                {
                    _liningInsulation = (_liningInsulation is null) ?
                        ThermalInsulationAnalyzer.GetSuitableThermalInsulation(_liningFireproofSurfaceTemperature, _maxSampleTemperature)[0] : _liningInsulation;
                    CalculateInsulationWidth();
                }
                else
                {
                    _liningInsulation = null;
                    _liningInsulationWidth = 0;
                }
            }
        }

        public ThermalInsulation LiningInsulation
        {
            get => _liningInsulation;

            set
            {
                _liningInsulation = value;
                CalculateInsulationWidth();
            }
        }
        
        public Furnace(
            double furnanceLength, double maxSampleTemperature, double ambientGasTemperature, double outerSurfaceTemperature, double fireproofWidth,
            bool isWithDoor, bool isDoubleLayer
            )
        {
            this._furnanceLength = furnanceLength;
            this._maxSampleTemperature = maxSampleTemperature;
            this._ambientGasTemperature = ambientGasTemperature;
            this._outerSurfaceTemperature = outerSurfaceTemperature;
            this._isWithDoor = isWithDoor;
            this._isDoubleLayer = isDoubleLayer;
            this._liningFireproofWidth = fireproofWidth;
        }

        abstract protected void CalculateFireprooSurfaceTemperature();

        abstract protected void CalculateInsulationWidth();

        abstract protected void CalculateOverlapSurfaceTemperature();
    }
}
