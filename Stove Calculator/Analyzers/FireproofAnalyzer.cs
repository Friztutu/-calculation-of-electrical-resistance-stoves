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
        public static List<Fireproof> GetFullLiningFireproofs()
        {
            List<Fireproof> query;

            using var context = new FireproofContext();
            var blogs = from b in context.Fireproof
                        select b;

            query = blogs.ToList();

            return query;
        }
        public static List<Fireproof> GetSuitableLiningFireproofs(double workTemperature)
        {
            List<Fireproof> query;

            using var context = new FireproofContext();
            var blogs = from b in context.Fireproof
                        where b.MaxTemperatureOfUse >= workTemperature
                        orderby b.MaxTemperatureOfUse, b.Density descending,
                        b.AValue + b.BValue * workTemperature
                        select b;

            query = blogs.ToList();

            return query;
        }

        public static List<Fireproof> GetSuitableOverlapFireproofs(double workTemperature)
        {
            List<Fireproof> query;

            using var context = new FireproofContext();
            var blogs = from b in context.Fireproof
                        orderby b.MaxTemperatureOfUse, b.Density descending,
                        b.AValue + b.BValue * workTemperature
                        select b;

            query = blogs.ToList();

            return query;
        }
    }
}
