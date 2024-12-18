using Stove_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stove_Calculator.Constans;
using System.Runtime.CompilerServices;
using RSAExtensions;

namespace Stove_Calculator.Furnace_parts
{
    public class CarborundHeater
    {
        Dictionary<double, double> _moveTable = new Dictionary<double, double>
        {
            [1.5] = 0.48,
            [2.0] = 0.6,
            [2.5] = 0.67,
            [3] = 0.71,
            [3.5] = 0.75,
            [4] = 0.79,
            [4.5] = 0.81,
            [5] = 0.83,
            [5.5] = 0.84,
            [6] = 0.85
        };

        private double _Q3;
        private double _P;
        private double _Wn;
        private List<CarborundumHeater>? _carborundumHeaters;
        private CarborundumHeater? _currentCarborundumHeaters;
        private double _moveT;
        private double _J;
        private double _P1;
        private double _W;
        private double _N;
        private double _Q;
        private double _U;
        private double _Up;
        private double _I;
        private double _n;
        private double _Ul0;
        private double _Il0;
        private double _Ul1;
        private double _Il1;
        private double _Uft0;
        private double _Ift0;
        private double _Uft1;
        private double _Ift1;
        private double _Ufz0;
        private double _Ifz0;
        private double _Ufz1;
        private double _Ifz1;

        private InputData _inputData;
        private ChamberLining _chamberLining;
        private Overlap _overlap;

        public double Q3 => _Q3;
        public double Q => _Q;
        public double P => _P;
        public double Wn => _Wn;
        public List<CarborundumHeater>? CarborundumHeaters => _carborundumHeaters;
        public double J => _J;
        public double P1 => _P1;
        public double W => _W;
        public double N => _N;
        public double U => _U;
        public double Up => _Up;
        public double I => _I;
        public double n => _n;
        public double Ul0 => _Ul0;
        public double Il0 => _Il0;
        public double Ul1 => _Ul1;
        public double Il1 => _Il1;
        public double Uft0 => _Uft0;
        public double Ift0 => _Ift0;
        public double Uft1 => _Uft1;
        public double Ift1 => _Ift1;
        public double Ufz0 => _Ufz0;
        public double Ifz0 => _Ifz0;
        public double Ufz1 => _Ufz1;
        public double Ifz1 => _Ifz1;


        public double MoveT
        {
            get => _moveT;

            set
            {
                _moveT = value;
                _J = _moveTable[_moveT];
                CalculateParameters();
            }
        }

        public CarborundumHeater? CurrentCarborundumHeaters
        {
            get => _currentCarborundumHeaters;

            set
            {
                _currentCarborundumHeaters = value;
                CalculateParameters();
            }
        }

        public CarborundHeater(InputData inputData, ChamberLining chamberLining,  Overlap overlap)
        {
            this._inputData = inputData;
            this._chamberLining = chamberLining;
            this._overlap = overlap;

            _carborundumHeaters = CarborundumHeater.GetPossibleHeaters(_chamberLining.L4);

            if (_carborundumHeaters.Count == 0) return;

            _currentCarborundumHeaters = _carborundumHeaters[0];
            _moveT = 1.5;
            _J = _moveTable[_moveT];
        }

        public void UpdateHeater()
        {
            _carborundumHeaters = CarborundumHeater.GetPossibleHeaters(_chamberLining.L4);
            _currentCarborundumHeaters = _carborundumHeaters[0];
        }

        private void CalculateParameters()
        {

            _Q3 = 2 * (_chamberLining.Q1 + _overlap.Q2);
            _Q = _chamberLining.Q1 + _overlap.Q2 + _Q3;
            _P = 0.001 * _Q;

            _Wn = 5.7 * Math.Pow(10, -11) * (Math.Pow(_inputData.t1, 4) - Math.Pow(_inputData.t1 - 100, 4));

            this._W = J * this.Wn;

            if (_currentCarborundumHeaters == null) return;

            _P1 = _currentCarborundumHeaters.WorkSurfaceArea * _W * Math.Pow(10, -3);
            _N = this.P / this.P1;

            _U = Math.Sqrt(1000 * P1 * _currentCarborundumHeaters.Resistance);
            _Up = 3 * U;
            _I = U / _currentCarborundumHeaters.Resistance;
            _n = Math.Ceiling(N) / 3;

            _Il0 = I;
            _Ul0 = _Up * Math.Ceiling(N);
            _Il1 = I * N;
            _Ul1 = Up;

            if (Math.Round(_n, 2) == Math.Ceiling(_n))
            {
                _Ift0 = I * Math.Sqrt(3);
                _Uft0 = _Up * _n;
                _Ift1 = _I * Math.Sqrt(3) * _n;
                _Uft1 = Up;
                _Ifz0 = _I;
                _Ufz0 = _Up * Math.Sqrt(3) * _n;
                _Ifz1 = _I * Math.Sqrt(3) * _n;
                _Ufz1 = _Up * Math.Sqrt(3);
            } else
            {
                _Ift0 = 0;
                _Uft0 = 0;
                _Ift1 = 0;
                _Uft1 = 0;
                _Ifz0 = 0;
                _Ufz0 = 0;
                _Ifz1 = 0;
                _Ufz1 = 0;
            }
        }
    }
}
