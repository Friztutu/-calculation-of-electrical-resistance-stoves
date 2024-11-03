using Stove_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Analyzers
{
    public class ThermalInsulationAnalyzer
    {
        public static List<ThermalInsulation> GetSuitableThermalInsulation(double fireproofSurfaceTemperature, double maxSampleTemperature)
        {
            List<ThermalInsulation> query;

            using (var context = new ThermalInsulationContext())
            {
                var blogs = from b in context.ThermalInsulation
                            where b.MaxTemperatureOfUse >= fireproofSurfaceTemperature
                            orderby b.MaxTemperatureOfUse, b.AValue + b.BValue * maxSampleTemperature, b.Density descending
                            select b;

                query = blogs.ToList();
                return query;
            }
        }
    }
}
