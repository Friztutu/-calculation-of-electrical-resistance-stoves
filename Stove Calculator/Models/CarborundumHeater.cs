using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Models
{
    public class CarborundumHeater
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

        public static List<CarborundumHeater> GetPossibleHeaters(double L4)
        {
            List<CarborundumHeater> query;

            using var context = new CarborundumHeatersContext();
            var blogs = from b in context.CarborundumHeaters
                        where b.WorkLength <= L4
                        select b;

            query = [.. blogs];

            return query;
        }
    }
}
