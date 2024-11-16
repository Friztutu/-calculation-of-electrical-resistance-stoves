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

namespace Stove_Calculator.Furnaces
{
    public abstract class Furnace
    {
        // Dimensions
        protected readonly double _furnanceLength;

        // Temperature parameters
        protected readonly double _workTemperature;
        protected readonly double _ambientGasTemperature;
        protected readonly double _outerSurfaceTemperature;

        // Furnace overlap parameters
        protected readonly bool _isWithDoor;
        protected readonly bool _isDoubleLayer;
        protected Fireproof _overlapFireproof;
        protected double _overlapFireproofWidth;
        protected ThermalInsulation _overlapInsulation;
        protected double _overlapInsulationWidth;
        protected double _overlapSurfaceTemperature;
        protected double _overlapLiningTemperature;

        // Lining parameters
        protected Fireproof _liningFireproof;
        protected double _liningFireproofWidth;
        protected double _liningFireproofSurfaceTemperature;
        protected ThermalInsulation _liningInsulation;
        protected double _liningInsulationWidth;

        // GETTERS
        public double FurnaceLength => _furnanceLength;
        public double WorkTemperature => _workTemperature;
        public double AmbientGasTemperature => _ambientGasTemperature;
        public double OuterSurfaceTemperature => _outerSurfaceTemperature;
        public bool IsWithDoor => _isWithDoor;
        public bool IsDoubleLayer => _isDoubleLayer;
        public double LiningFireproofSurfaceTemperature => _liningFireproofSurfaceTemperature;
        public double LiningInsulationWidth => _liningInsulationWidth;
        public double OverlapSurfaceTemperature => _overlapSurfaceTemperature;
        public double OverlapLiningTemperature => _overlapLiningTemperature;

        public double LiningFireproofWidth
        {
            get => _liningFireproofWidth;

            set
            {
                _liningFireproofWidth = value;

                if (_liningFireproof == null) return;

                CalculateLiningFireproofSurfaceTemperature();

                if (_liningInsulation == null) return;

                CalculateInsulationWidth();
            }
        }

        public Fireproof LiningFireproof
        {
            get => _liningFireproof;

            set
            {
                _liningFireproof = value;
                CalculateLiningFireproofSurfaceTemperature();

                if (_liningInsulation == null) return;

                CalculateInsulationWidth();
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

        public double OverlapFireproofWidth
        {
            get => _overlapFireproofWidth;

            set
            {
                _overlapFireproofWidth = value;

                if (_overlapFireproof == null || _overlapInsulation == null) return;

                CalculateOverlapSurfaceTemperature();
            }
        }

        public double OverlapInsulationWidth
        {
            get => _overlapInsulationWidth;

            set
            {
                _overlapInsulationWidth = value;

                if (_overlapFireproof == null || _overlapInsulation == null) return;

                CalculateOverlapSurfaceTemperature();
            }
        }

        public Fireproof OverlapFireproof
        {
            get => _overlapFireproof;

            set
            {
                _overlapFireproof = value;

                if (_overlapInsulation == null) return;

                CalculateOverlapSurfaceTemperature();
            }
        }

        public ThermalInsulation OverlapInsulation
        {
            get => _overlapInsulation;

            set
            {
                _overlapInsulation = value;

                if (_overlapFireproof == null) return;

                CalculateOverlapSurfaceTemperature();
            }
        }

        public Furnace(
            double furnanceLength, double workTemperature, double ambientGasTemperature, double outerSurfaceTemperature,
            bool isWithDoor, bool isDoubleLayer
            )
        {
            this._furnanceLength = furnanceLength;
            this._workTemperature = workTemperature;
            this._ambientGasTemperature = ambientGasTemperature;
            this._outerSurfaceTemperature = outerSurfaceTemperature;
            this._isWithDoor = isWithDoor;
            this._isDoubleLayer = isDoubleLayer;

            double defaultValueWidth = 0;
            this._liningFireproofWidth = defaultValueWidth;
            this._liningInsulationWidth = defaultValueWidth;
            this._overlapFireproofWidth = defaultValueWidth;
            this._overlapInsulationWidth = defaultValueWidth;
        }

        abstract protected void CalculateLiningFireproofSurfaceTemperature();

        abstract protected void CalculateInsulationWidth();

        protected void CalculateOneLayerOverlapSurfaceTemperature()
        {
            double a3 = _overlapFireproof.AValue;
            double b3 = _overlapFireproof.BValue;
            double h3 = _overlapFireproofWidth;
            double j = Constant.J;
            double i = Constant.I;
            double t0 = _ambientGasTemperature;
            double t1 = _workTemperature;

            double firstBracket = 2 * (b3 + 2 * h3 * j);
            double secondBracket = 2 * a3 + 2 * h3 * i - 2 * h3 * j * t0;
            double thirdBracket = 2 * a3 * t1 + b3 * Math.Pow(t1, 2) + 2 * h3 * i * t0;

            _overlapSurfaceTemperature = 1 / firstBracket * (-secondBracket + Math.Sqrt(Math.Pow(secondBracket, 2) + 2 * firstBracket * thirdBracket));
        }

        protected void CalculateDoubleLayerOverlapSurfaceTemperature() 
        {
            double y2, q2, x3, x4, t5, tz;

            double i = Constant.I;
            double j = Constant.J;
            double a3 = _overlapFireproof.AValue;
            double b3 = _overlapFireproof.BValue;
            double a4 = _overlapInsulation.AValue;
            double b4 = _overlapInsulation.BValue;
            double h3 = _overlapFireproofWidth;
            double h4 = _overlapInsulationWidth;
            double t1 = _workTemperature;
            double t0 = _ambientGasTemperature;
            double t4 = _ambientGasTemperature - 0.01;

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

            } while (Math.Round(tz, 1) != Math.Round(t4, 1) && t4 < _workTemperature);

            this._overlapSurfaceTemperature = t5;
            this._overlapLiningTemperature = t4;
        }

        protected void CalculateOverlapSurfaceTemperature()
        {
            if(_isDoubleLayer)
            {
                CalculateDoubleLayerOverlapSurfaceTemperature();
            } else
            {
                CalculateOneLayerOverlapSurfaceTemperature();
            }
        }

        public void resetLiningCalculation()
        {
            double defaultValueWidth = 0;

            this._liningFireproofWidth = defaultValueWidth;
            this._liningInsulationWidth = defaultValueWidth;
            this._overlapFireproofWidth = defaultValueWidth;
            this._overlapInsulationWidth = defaultValueWidth;

            this._liningFireproof = null;
            this._liningInsulation = null;
            this._overlapFireproof = null;
            this._overlapInsulation = null;
        }

        public void resetOverlapCalculation()
        {
            double defaultValueWidth = 0;

            this._overlapFireproofWidth = defaultValueWidth;
            this._overlapInsulationWidth = defaultValueWidth;

            this._overlapFireproof = null;
            this._overlapInsulation = null;
        }
    }
}
