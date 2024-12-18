using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Models
{
    public class ThermalInsulation
    {
        [Key]
        public required int ThermalInsulationId { get; set; }
        public required string Name { get; set; }
        public required double MaxTemperatureOfUse { get; set; }
        public required double AValue { get; set; }
        public required double BValue { get; set; }
        public required double Density { get; set; }

        public static List<ThermalInsulation> GetFullInsulation()
        {
            List<ThermalInsulation> query;

            using var context = new ThermalInsulationContext();
            var blogs = from b in context.ThermalInsulation
                        select b;

            query = [.. blogs];
            return query;
        }

        public static List<ThermalInsulation> GetPossibleLiningInsulation(
            double t2)
        {
            List<ThermalInsulation> query;

            using var context = new ThermalInsulationContext();
            var blogs = from b in context.ThermalInsulation
                        where b.MaxTemperatureOfUse >= t2
                        select b;

            query = [.. blogs];
            return query;
        }

        public static List<ThermalInsulation> GetPossibleOverlapInsulation()
        {
            List<ThermalInsulation> query;

            using var context = new ThermalInsulationContext();
            var blogs = from b in context.ThermalInsulation
                        where b.MaxTemperatureOfUse >= 950
                        select b;

            query = [.. blogs];
            return query;
        }
    }
}
