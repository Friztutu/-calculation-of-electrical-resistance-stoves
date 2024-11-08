using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Stove_Calculator.Models;

namespace Stove_Calculator.Analyzers
{
    public class FireproofAnalyzer
    {
        public static List<Fireproof> GetSuitableLiningFireproofs(double maxSampleTemperature)
        {
            List<Fireproof> query;

            using (var context = new FireproofContext())
            {
                var blogs = from b in context.Fireproof
                            where b.MaxTemperatureOfUse >= maxSampleTemperature
                            orderby b.MaxTemperatureOfUse, b.Density descending,
                            b.AValue + b.BValue * maxSampleTemperature
                            select b;

                query = blogs.ToList();

                return query;
            }
        }

        public static List<Fireproof> GetSuitableOverlapFireproofs(double maxSampleTemperature)
        {
            List<Fireproof> query;

            using (var context = new FireproofContext())
            {
                var blogs = from b in context.Fireproof
                            where b.MaxTemperatureOfUse >= maxSampleTemperature
                            orderby b.MaxTemperatureOfUse, b.Density descending,
                            b.AValue + b.BValue * maxSampleTemperature
                            select b;

                query = blogs.ToList();

                return query;
            }
        }
    }
}
