using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Stove_Calculator.Models
{
    public class FireproofContext : DbContext
    {
        public DbSet<Fireproof> Fireproof { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=fipeproof.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fireproof>().HasData(
                new Fireproof { FireproofId = 1, Name = "Графит", MaxTemperatureOfUse = 2500, AValue = 3.14, BValue = 0.0021, Density = 1500},
                new Fireproof { FireproofId = 2, Name = "Карборунд-рефракс", MaxTemperatureOfUse = 2500, AValue = 37.1, BValue = -0.00344, Density = 2100 },
                new Fireproof { FireproofId = 3, Name = "Карборунд-каброфракс", MaxTemperatureOfUse = 2000, AValue = 2.62, BValue = -0.00116, Density = 2100 },
                new Fireproof { FireproofId = 4, Name = "Корунд литой", MaxTemperatureOfUse = 1850, AValue = 58, BValue = -0.029, Density = 1850 },
                new Fireproof { FireproofId = 5, Name = "Димас высокоплотный", MaxTemperatureOfUse = 1700, AValue = 1.58, BValue = 0.00038, Density = 1660 },
                new Fireproof { FireproofId = 6, Name = "Муллит литой", MaxTemperatureOfUse = 1650, AValue = 0.28, BValue = -0.000169, Density = 1700 },
                new Fireproof { FireproofId = 7, Name = "Димас", MaxTemperatureOfUse = 1600, AValue = 0.815, BValue = 0.00067, Density = 1620 },
                new Fireproof { FireproofId = 8, Name = "Магнезит", MaxTemperatureOfUse = 1600, AValue = 6.28, BValue = -0.0027, Density = 1580 },
                new Fireproof { FireproofId = 9, Name = "Динас-легковес", MaxTemperatureOfUse = 1450, AValue = 0.29, BValue = 0.00037, Density = 1200 },
                new Fireproof { FireproofId = 10, Name = "Каолин плотный", MaxTemperatureOfUse = 1400, AValue = 1.75, BValue = 0.00086, Density = 2500 },
                new Fireproof { FireproofId = 11, Name = "Шамот класса А", MaxTemperatureOfUse = 1350, AValue = 0.88, BValue = 0.00023, Density = 2500 },
                new Fireproof { FireproofId = 12, Name = "Шамот класса Б", MaxTemperatureOfUse = 1350, AValue = 0.465, BValue = 0.00038, Density = 2500 },
                new Fireproof { FireproofId = 13, Name = "Шамот", MaxTemperatureOfUse = 1300, AValue = 0.7, BValue = 0.00064, Density = 2500 },
                new Fireproof { FireproofId = 14, Name = "Шамот-легковес А", MaxTemperatureOfUse = 1300, AValue = 0.314, BValue = -0.000241, Density = 2500 },
                new Fireproof { FireproofId = 15, Name = "Шамот-легковес Б", MaxTemperatureOfUse = 1250, AValue = 0.225, BValue = 0.00022, Density = 2500 },
                new Fireproof { FireproofId = 16, Name = "Шамот-ультралегковес", MaxTemperatureOfUse = 1100, AValue = 0.116, BValue = 0.00016, Density = 2500 }
                );
        }
    }
}
