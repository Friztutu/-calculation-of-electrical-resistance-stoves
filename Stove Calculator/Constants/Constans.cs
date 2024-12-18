using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Constans
{
    public class Constant
    {
        private static readonly double _i = 9.304;
        private static readonly double _j = 0.05815;

        private static readonly double[] t = { 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6 };
        private static readonly double[] j = { 0.48, 0.60, 0.67, 0.71, 0.75, 0.79, 0.81, 0.83, 0.84, 0.85 };

        public static double I => _i;
        public static double J => _j;

        public static double[] T => t;
        public static double[] J_ => j;
    }
}
