using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Models
{
    public class HeaterMaterial
    {
        [Key]
        public required int HeaterMaterialId { get; set; }
        public required string HeaterMaterialName { get; set; }
        public required int MaximumTemperatureOfUse { get; set; }
        public required double I { get; set; }
        public required double J { get; set; }
    }
}
