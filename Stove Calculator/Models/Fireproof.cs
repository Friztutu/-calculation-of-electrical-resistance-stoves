using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stove_Calculator.Models
{
    public class Fireproof
    {
        [Key]
        public required int FireproofId { get; set; }
        public required string Name { get; set; }
        public required double MaxTemperatureOfUse { get; set; }
        public required double AValue { get; set; }
        public required double BValue { get; set; }
        public required double Density { get; set; }

        public static List<Fireproof> GetFullLiningFireproofs()
        {
            List<Fireproof> query;

            using var context = new FireproofContext();
            var blogs = from b in context.Fireproof
                        select b;

            query = [.. blogs];

            return query;
        }
        public static List<Fireproof> GetPossibleLiningFireproofs(double workTemperature)
        {
            List<Fireproof> query;

            using var context = new FireproofContext();
            var blogs = from b in context.Fireproof
                        where b.MaxTemperatureOfUse >= workTemperature
                        select b;

            query = [.. blogs];

            return query;
        }

        public static List<Fireproof> GetPossibleOverlapFireproofs(double workTemperature)
        {
            List<Fireproof> query;

            using var context = new FireproofContext();
            var blogs = from b in context.Fireproof
                        where b.MaxTemperatureOfUse >= workTemperature
                        select b;

            query = [.. blogs];

            return query;
        }
    }


}
