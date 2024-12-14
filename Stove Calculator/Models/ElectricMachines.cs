using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Models
{
    public class ElectricMachines
    {
        [Key]
        public required int ElectricMachinesId { get; set; }
        public required string Name { get; set; }
        public required int NumberOfPhase { get; set; }
        public required int Voltage { get; set; }
        public required int[] MaximumLoadCurrent { get; set; }
    }
}
