using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Stove_Calculator.Models
{
    public class Fireproof
    {
        public required int FireproofId { get; set; }
        public required string Name { get; set; }
        public required double MaxTemperatureOfUse { get; set; }
        public required double AValue { get; set; }
        public required double BValue { get; set; }
        public required double Density { get; set; }
    }
}
