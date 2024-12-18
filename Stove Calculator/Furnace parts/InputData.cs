using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Furnace_parts
{
    public class InputData(
        bool isDoor, bool isDoubleLayer, double l1,
        double l2, double l3, double t0,
        double t1, double t3)
    {
        // Input Data
        private readonly bool _isDoor = isDoor;
        private readonly bool _isDoubleLayer = isDoubleLayer;
        private readonly double _L1 = l1;
        private readonly double _L2 = l2;
        private readonly double _L3 = l3;
        private readonly double _t0 = t0;
        private readonly double _t1 = t1;
        private readonly double _t3 = t3;

        // Input Data Getters
        public bool IsDoor => _isDoor;
        public bool IsDoubleLayer => _isDoubleLayer;
        public double L1 => _L1;
        public double L2 => _L2;
        public double L3 => _L3;
        public double t0 => _t0;
        public double t1 => _t1;
        public double t3 => _t3;
    }
}
