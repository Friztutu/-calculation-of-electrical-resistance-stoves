using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Models
{
    public class HeaterMaterialContext : DbContext
    {
        public DbSet<HeaterMaterial> HeaterMaterial { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=heatermaterial.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeaterMaterial>().HasData(
                new HeaterMaterial
                {
                    HeaterMaterialId = 1,
                    HeaterMaterialName = "Фехраль Х13Ю04",
                    MaximumTemperatureOfUse = 700,
                    I = 1.26 * Math.Pow(10, 6),
                    J = 0.6 * Math.Pow(10, 10)
                },
                new HeaterMaterial
                {
                    HeaterMaterialId = 2,
                    HeaterMaterialName = "Сталь Х25Н20С2",
                    MaximumTemperatureOfUse = 800,
                    I = 0.92 * Math.Pow(10, 6),
                    J = 3.8 * Math.Pow(10, 10)
                },
                new HeaterMaterial
                {
                    HeaterMaterialId = 3,
                    HeaterMaterialName = "Нихром Х15Н60",
                    MaximumTemperatureOfUse = 950,
                    I = 1.1 * Math.Pow(10, 6),
                    J = 1.4 * Math.Pow(10, 10)
                },
                new HeaterMaterial
                {
                    HeaterMaterialId = 4,
                    HeaterMaterialName = "Нихром X20H80",
                    MaximumTemperatureOfUse = 1100,
                    I = 1.1 * Math.Pow(10, 6),
                    J = 8.5 * Math.Pow(10, 11)
                },
                new HeaterMaterial
                {
                    HeaterMaterialId = 5,
                    HeaterMaterialName = "Сплав ОХ23Ю5А",
                    MaximumTemperatureOfUse = 1150,
                    I = 1.4 * Math.Pow(10, 6),
                    J = 0.5 * Math.Pow(10, 10)
                },
                new HeaterMaterial
                {
                    HeaterMaterialId = 6,
                    HeaterMaterialName = "Сплав ОХ27Ю5А",
                    MaximumTemperatureOfUse = 1250,
                    I = 1.4 * Math.Pow(10, 6),
                    J = 0.5 * Math.Pow(10, 10)
                },
                new HeaterMaterial
                {
                    HeaterMaterialId = 7,
                    HeaterMaterialName = "Карборунд(силит), SiC",
                    MaximumTemperatureOfUse = 1450,
                    I = 0.8 * Math.Pow(10, 3),
                    J = 1.9 * Math.Pow(10, 3)
                },
                new HeaterMaterial
                {
                    HeaterMaterialId = 8,
                    HeaterMaterialName = "Дисилицид молибдена MoSi2",
                    MaximumTemperatureOfUse = 1650,
                    I = 3.6 * Math.Pow(10, 6),
                    J = 0
                }
            );
        }
    }
}
