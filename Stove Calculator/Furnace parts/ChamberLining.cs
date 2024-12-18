using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stove_Calculator.Models;
using Stove_Calculator.Constans;

namespace Stove_Calculator.Furnace_parts
{
    public class ChamberLining
    {
        private readonly InputData _inputData;
        public InputData inputData => _inputData;

        // All posible lining Fireproofs and Insulations
        private List<Fireproof>? _liningFireproofs;
        private List<ThermalInsulation>? _liningInsulations;

        // Possible lining and insulations getters
        public List<Fireproof>? LiningFireproofs => _liningFireproofs;
        public List<ThermalInsulation>? LiningInsulations => _liningInsulations;

        // Lining calculated data
        private Fireproof? _currentLiningFireproof;
        private ThermalInsulation? _currentLiningInsulation;
        private double _h1;
        private double _t2;
        private double _h2;
        private double _q1;
        private double _y1;
        private double _x1;
        private double _x2;

        // Lining calculated data getters
        public double t2 => _t2;
        public double h2 => _h2;
        public double q1 => _q1;
        public double y1 => _y1;
        public double x1 => _x1;
        public double x2 => _x2;

        // Lining other parameters
        private double _F0;
        private double _F1;
        private double _F2;
        private double _F3;
        private double _Ft;
        private double _Q1;
        private double _L4;

        // Lining other parameters GETTERS
        public double F0 => _F0;
        public double F1 => _F1;
        public double F2 => _F2;
        public double F3 => _F3;
        public double Ft => _Ft;
        public double Q1 => _Q1;
        public double L4 => _L4;

        public double h1
        {
            get => _h1;

            set
            {
                _h1 = value;

                UpdateData();
            }
        }

        public Fireproof? CurrentLiningFireproof
        {
            get => _currentLiningFireproof;

            set
            {
                _currentLiningFireproof = value;

                UpdateData();
            }
        }

        public ThermalInsulation? CurrentLiningInsulation
        {
            get => _currentLiningInsulation;

            set
            {
                _currentLiningInsulation = value;

                CalculateLiningInsulationWidth();
                CalculateLiningParameters();
            }
        }


        public ChamberLining(InputData inputData)
        {
            _inputData = inputData;

            this._liningFireproofs = Fireproof.GetPossibleLiningFireproofs(this._inputData.t1);
            this._currentLiningFireproof = this._liningFireproofs[0];

            this._liningInsulations = ThermalInsulation.GetFullInsulation();
            this._currentLiningInsulation = this._liningInsulations[0];
        }

        private void CalculateLiningFireproofTemperature()
        {
            if (_currentLiningFireproof == null) return;

            this._y1 = Constant.I + Constant.J * this._inputData.t3;
            this._q1 = this._y1 * (this._inputData.t3 - this._inputData.t0);

            double sqrtExpression = Math.Pow(2 * _currentLiningFireproof.AValue, 2) - 4 * _currentLiningFireproof.BValue *
                (2 * _h1 * _q1 - 2 * _currentLiningFireproof.AValue * _inputData.t1 - _currentLiningFireproof.BValue *
                Math.Pow(_inputData.t1, 2));

            this._t2 = (-2 * _currentLiningFireproof.AValue + Math.Sqrt(sqrtExpression)) / (2 * _currentLiningFireproof.BValue);
            this._x1 = _currentLiningFireproof.AValue + (_currentLiningFireproof.BValue * (_inputData.t1 + _t2) / 2);

            this._liningInsulations = ThermalInsulation.GetPossibleLiningInsulation(_t2);

            if(_liningInsulations.Count > 0)
            {
                this._currentLiningInsulation = this._liningInsulations[0];
            } else
            {
                this._liningInsulations = null;
                this._currentLiningInsulation = null;
            }
        }

        private void CalculateLiningInsulationWidth()
        {
            if (_currentLiningInsulation == null) return;

            this._x2 = _currentLiningInsulation.AValue + (_currentLiningInsulation.BValue * ((_t2 + _inputData.t3) / 2));

            this._h2 = (_x2 * (_t2 - _inputData.t3) / _q1);
        }

        private void CalculateLiningParameters()
        {
            _L4 = _inputData.L3;

            _F1 = _inputData.L1 * _inputData.L2 + 2 * _inputData.L1 * _L4 + 2 * _inputData.L2 * L4;
            _F2 = (_inputData.L1 + 2 * h1) * (_inputData.L2 + 2 * h1) + 2 * (_inputData.L1 + 2 * h1) * 
                (L4 + h1) + 2 * (_inputData.L2 + 2 * h1) * (L4 + h1);
            _F3 = (_inputData.L1 + 2 * h1 + 2 * h2) * (_inputData.L2 + 2 * h1 + 2 * h2) + 
                2 * (_inputData.L1 + 2 * h1 + 2 * h2) * (L4 + h1 + h2) +
                2 * (_inputData.L2 + 2 * h1 + 2 * h2) * (L4 + h1 + h2);

            if (F2 / F1 <= 2)
            {
                _F0 = (F1 + F2) / 2;
            }
            else
            {
                _F0 = Math.Sqrt(F1 * F2);
            }

            if (F3 / F2 <= 2)
            {
                _Ft = (F3 + F2) / 2;
            }
            else
            {
                _Ft = Math.Sqrt(F3 * F2);
            }

            _Q1 = (_inputData.t1 - _inputData.t0) / (h1 / (x1 * F0) + h2 / (x2 * Ft) + 1 / (y1 * F3));
        }

        private void UpdateData()
        {
            CalculateLiningFireproofTemperature();

            if (_liningInsulations != null)
            {
                CalculateLiningInsulationWidth();
                CalculateLiningParameters();
            }
        }
    }
}
