using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Models
{
    public class MolybdenumHeaters
    {
        [Key]
        public required int MolybdenumHeatersId {  get; set; }
        public required string Name { get; set; }
        public required double WorkLength { get; set; }
        public required double ExpandedWorkLength { get; set; }
        public required double Length { get; set; }
        public required double WorkSurfaceArea { get; set; }

        public static List<MolybdenumHeaters> GetPossibleHeaters(double L4)
        {
            List<MolybdenumHeaters> query;

            using var context = new MolybdenumHeatersContext();
            var blogs = from b in context.MolybdenumHeaters
                        where b.WorkLength <= L4
                        select b;

            query = [.. blogs];

            return query;
        }
    }
}
