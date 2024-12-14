using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Models
{
    public class CarborundumHeaters
    {
        [Key]
        public required int CarborunbumHeatersId { get; set; }
        public required string Name { get; set; }
        public required double WorkLength { get; set; }
        public required double Length { get; set; }
        public required double WorkDiameter { get; set; }
        public required double Diameter { get; set; }
        public required double WorkSurfaceArea { get; set; }
        public required double Resistance { get; set; }
    }
}
