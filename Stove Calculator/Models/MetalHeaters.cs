using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Models
{
    public class MetalHeaters
    {
        [Key]
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string HeaterShape { get; set; }
        public required string PlacementMethod { get; set; }
        public required double J { get; set; }
    }
}
