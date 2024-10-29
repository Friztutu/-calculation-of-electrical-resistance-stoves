using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Stove_Calculator.Models
{
    public class ThermalInsulationContext : DbContext
    {
        public DbSet<ThermalInsulation> ThermalInsulation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=thermalinsulation.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ThermalInsulation>().HasData(
                new ThermalInsulation { ThermalInsulationId = 1, Name = "Асбовермикулит", MaxTemperatureOfUse = 1100, AValue = 0.072, BValue = 0.00026, Density = 250},
                new ThermalInsulation { ThermalInsulationId = 2, Name = "Каолиновая вата", MaxTemperatureOfUse = 1100, AValue = 0.03, BValue = 0.0002, Density = 100 },
                new ThermalInsulation { ThermalInsulationId = 3, Name = "Диатомит-обожженный порошок", MaxTemperatureOfUse = 1000, AValue = 0.163, BValue = 0.00043, Density = 450 },
                new ThermalInsulation { ThermalInsulationId = 4, Name = "Диатомит-кирпичь", MaxTemperatureOfUse = 950, AValue = 0.116, BValue = 0.00015, Density = 700 },
                new ThermalInsulation { ThermalInsulationId = 5, Name = "Диатомит-необожженный порошок", MaxTemperatureOfUse = 900, AValue = 0.091, BValue = 0.00028, Density = 650 },
                new ThermalInsulation { ThermalInsulationId = 6, Name = "Шлаковая минеральная вата", MaxTemperatureOfUse = 750, AValue = 0.048, BValue = 0.00014, Density = 200 },
                new ThermalInsulation { ThermalInsulationId = 7, Name = "Вермикулит", MaxTemperatureOfUse = 600, AValue = 0.081, BValue = 0.00023, Density = 250 },
                new ThermalInsulation { ThermalInsulationId = 8, Name = "Пеношамот", MaxTemperatureOfUse = 600, AValue = 0.28, BValue = 0.00023, Density = 800 },
                new ThermalInsulation { ThermalInsulationId = 9, Name = "Пенодинас", MaxTemperatureOfUse = 600, AValue = 0.8, BValue = 0, Density = 680 },
                new ThermalInsulation { ThermalInsulationId = 10, Name = "Пенодиатомит", MaxTemperatureOfUse = 500, AValue = 0.093, BValue = 0.0002, Density = 600 },
                new ThermalInsulation { ThermalInsulationId = 11, Name = "Асбест", MaxTemperatureOfUse = 450, AValue = 0.157, BValue = 0.00014, Density = 835 },
                new ThermalInsulation { ThermalInsulationId = 12, Name = "Стекловолокно", MaxTemperatureOfUse = 450, AValue = 0.029, BValue = 0.00029, Density = 200 }
                );
        }
    }
}
