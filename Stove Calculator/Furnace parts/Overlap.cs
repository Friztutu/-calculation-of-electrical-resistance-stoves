using Stove_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Stove_Calculator.Constans;
using CSJ2K.j2k.wavelet.analysis;
using Microsoft.EntityFrameworkCore;

namespace Stove_Calculator.Furnace_parts
{
    public class Overlap
    {
        private InputData _inputData;

        // All possible overlap fireproofs and insulations
        private List<Fireproof>? _overlapFireproofs;
        private List<ThermalInsulation>? _overlapInsulations;

        // All possible overlap fireproofs and insulations GETTERS
        public List<Fireproof>? OverlapFireproofs => _overlapFireproofs;
        public List<ThermalInsulation>? OverlapInsulations => _overlapInsulations;

        // Overlap parameters data
        private Fireproof? _currentOverlapFireproof;
        private ThermalInsulation? _currentOverlapInsulation;
        private double _h3;
        private double _h4;
        private double _t4;
        private double _t5;
        private double _x3;
        private double _y2;
        private double _q2;
        private double _x4;
        private double _F4;
        private double _Q2;

        // Overlap parameters GETTERS
        public double t4 => _t4;
        public double t5 => _t5;
        public double x3 => _x3;
        public double y2 => _y2;
        public double q2 => _q2;
        public double x4 => _x4;
        public double F4 => _F4;
        public double Q2 => _Q2;

        public Fireproof? CurrentOverlapFireproof
        {
            get => _currentOverlapFireproof;

            set
            {
                _currentOverlapFireproof = value;

                UpdateData();
            }
        }

        public ThermalInsulation? CurrentOverlapInsulation
        {
            get => _currentOverlapInsulation;

            set
            {
                _currentOverlapInsulation = value;

                UpdateData();
            }
        }

        public double h3
        {
            get => _h3;

            set
            {
                _h3 = value;

                UpdateData();
            }
        }

        public double h4
        {
            get => _h4;

            set
            {
                _h4 = value;

                UpdateData();
            }
        }

        public Overlap(InputData inputData) 
        {
            this._inputData = inputData;

            this._overlapFireproofs = Fireproof.GetPossibleOverlapFireproofs(_inputData.t1);
            this._overlapInsulations = ThermalInsulation.GetPossibleOverlapInsulation();

            this._currentOverlapFireproof = _overlapFireproofs[0];
            this._currentOverlapInsulation = _overlapInsulations[0];

            this._h3 = 0;
            this._h4 = 0;
        }

        public void CalculateOneLayerOverlap()
        {
            if (_currentOverlapFireproof == null) return;

            double a3 = _currentOverlapFireproof.AValue;
            double b3 = _currentOverlapFireproof.BValue;
            double j = Constant.J;
            double i = Constant.I;

            double firstBracket = 2 * (b3 + 2 * h3 * j);
            double secondBracket = 2 * a3 + 2 * h3 * i - 2 * h3 * j * _inputData.t0;
            double thirdBracket = 2 * a3 * _inputData.t1 + b3 * Math.Pow(_inputData.t1, 2) + 
                2 * h3 * i * _inputData.t0;

            this._t4 = 1 / firstBracket * 
                (-secondBracket + Math.Sqrt(Math.Pow(secondBracket, 2) + 2 * firstBracket * thirdBracket));

            this._x3 = a3 + (b3 * (_inputData.t1 + _t4) / 2);
            this._y2 = i + j * _t4;
            this._q2 = (_x3 * (_inputData.t1 - _t4) / _h3);
        }

        public void CalculateDoubleLayerOverlap()
        {
            if (_currentOverlapFireproof == null || _currentOverlapInsulation == null) return;

            double tz;
            double i = Constant.I;
            double j = Constant.J;
            double a3 = _currentOverlapFireproof.AValue;
            double b3 = _currentOverlapFireproof.BValue;
            double a4 = _currentOverlapInsulation.AValue;
            double b4 = _currentOverlapInsulation.BValue;
            double t0 = _inputData.t0;
            double t1 = _inputData.t1;
            _t4 = t0 - 0.01;

            do
            {
                _t4 += 0.1;

                double firstBracket = 2 * (b3 * _h4 + b4 * _h3);
                double secondBracket = 2 * a3 * _h4 + 2 * a4 * _h3;
                double thirdBracket = 2 * a3 * _h4 * t1 + b3 * _h4 * Math.Pow(t1, 2);
                double fouthBracket = 2 * a4 * _h3 * _t4 + b4 * _h3 * Math.Pow(_t4, 2);

                _t5 = (1 / firstBracket) * (-secondBracket + Math.Sqrt(Math.Pow(secondBracket, 2) + 
                    2 * firstBracket * (thirdBracket + fouthBracket)));

                _x3 = a3 + (b3 * (t1 + _t5) / 2);
                _q2 = (_x3 * (t1 - _t5)) / _h3;

                tz = (-(i - j * t0) + Math.Sqrt(Math.Pow(i - j * t0, 2) + 4 * j * (i * t0 + _q2))) / (2 * j);

            } while (Math.Round(tz, 1) != Math.Round(_t4, 1) && _t4 < t1);

            this._x4 = a4 + (b4 * (_t5 + _t4) / 2);
            this._y2 = i + j * _t4;
            double _q2Temp = _x4 * (_t5 - _t4) / h3;

            //if(Math.Round(_q2Temp, 0) != Math.Round(_q2, 0)) 
            //{
            //    throw new Exception("Не совпадают значения q2, попробуйте другие параметры перекрытия");
            //}
        }

        public void CalculateParameters()
        {
            _F4 = _inputData.L1 * _inputData.L2;
            _Q2 = q2 * F4;
        }

        public void UpdateData()
        {
            if (_inputData.IsDoubleLayer)
            {
                CalculateDoubleLayerOverlap();
            }
            else
            {
                CalculateOneLayerOverlap();
            }

            CalculateParameters();
        }
    }
}
