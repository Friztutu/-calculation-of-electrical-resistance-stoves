using RSAExtensions;
using Stove_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Furnace_parts
{
    public class MolybdenHeater
    {
        private readonly Dictionary<int, double> _pTable = new Dictionary<int, double>
        {
            [700] = 1.5,
            [1400] = 2.8,
            [1450] = 2.9,
            [1500] = 3.0,
            [1550] = 3.1,
            [1600] = 3.2
        };

        private readonly double J = 0.87;

        private double _Wn;
        private double _W;
        private double _Pp;
        private double _P1;
        private double _R;
        private double _P;
        private double _Q3;
        private double _Q;
        private double _p;
        private double _N;
        private double _U;
        private double _I;
        private double _Up;
        private double _n;

        public double Wn => _Wn;
        public double W => _W;
        public double Pp => _Pp;
        public double P1 => _P1;
        public double R => _R;
        public double Q3 => _Q3;
        public double Q => _Q;
        public double P => _P;
        public double N => _N;
        public double U => _U;
        public double I => _I;
        public double Up => _Up;
        public double n => _n;

        private MolybdenumHeaters _currentMolybdenHeater;
        private List<MolybdenumHeaters> _molybdenHeaters;

        public MolybdenumHeaters CurrentMolybdenHeater {
            get => _currentMolybdenHeater;

            set
            {
                _currentMolybdenHeater = value;
                CalculateParameters();
            }
        }

        
        public List<MolybdenumHeaters> MolybdenHeaters => _molybdenHeaters;

        private Overlap _overlap;
        private ChamberLining _chamberLining;
        private InputData _inputData;

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

        public MolybdenHeater(InputData inputData, ChamberLining chamberLining, Overlap overlap)
        {
            _inputData = inputData;
            _chamberLining = chamberLining;
            _overlap = overlap;

            if (_inputData.t1 <= 1000)
            {
                _p = _pTable[700];
            }
            else if (_inputData.t1 <= 1410)
            {
                _p = _pTable[1400];
            } else if(_inputData.t1 <= 1460)
            {
                _p = _pTable[1450];
            } else if (inputData.t1 <= 1510)
            {
                _p = _pTable[1500];
            } else if (_inputData.t1 <= 1560)
            {
                _p = _pTable[1550];
            } else
            {
                _p = _pTable[1600];
            }
        }

        public void UpdateHeater()
        {
            _molybdenHeaters = MolybdenumHeaters.GetPossibleHeaters(_chamberLining.L4);
            _currentMolybdenHeater = _molybdenHeaters[0];
        }

        public void CalculateParameters()
        {
            _Q3 = 3 * (_chamberLining.Q1 + _overlap.Q2);
            _Q = _chamberLining.Q1 + _overlap.Q2 + _Q3;
            _P = 0.001 * _Q;

            _Wn = 5.7 * Math.Pow(10, -11) * (Math.Pow(_inputData.t1, 4) - Math.Pow(_inputData.t1 - 100, 4));

            _W = J * _Wn;
            _Pp = _currentMolybdenHeater.WorkSurfaceArea * _W * Math.Pow(10, -3);
            _P1 = _Pp * (1 + (7.5 * Math.Pow(10, -7) * _currentMolybdenHeater.ExpandedWorkLength / _p * _currentMolybdenHeater.WorkLength));
            _N = _P / _P1;

            _R = 3.54 * 10000 * (_p * _currentMolybdenHeater.WorkLength + 7.5 * Math.Pow(10, -7) * _currentMolybdenHeater.ExpandedWorkLength);
            _U = Math.Sqrt(1000 * _P1 * _R);
            _Up = 3 * _U;
            _I = _U / _R;
            _n = _N / 3;

            _Il0 = I;
            _Ul0 = _Up * Math.Ceiling(N);
            _Il1 = I * N;
            _Ul1 = Up;
            _Ift0 = I * Math.Sqrt(3);
            _Uft0 = _Up * _n;
            _Ift1 = _I * Math.Sqrt(3) * _n;
            _Uft1 = Up;
            _Ifz0 = _I;
            _Ufz0 = _Up * Math.Sqrt(3) * _n;
            _Ifz1 = _I * Math.Sqrt(3) * _n;
            _Ufz1 = _Up * Math.Sqrt(3);
        }
    }
}