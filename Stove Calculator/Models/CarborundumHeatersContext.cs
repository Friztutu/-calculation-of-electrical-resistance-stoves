using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Models
{
    public class CarborundumHeatersContext : DbContext
    {
        public DbSet<CarborundumHeater> CarborundumHeaters { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=carborundumheaters.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarborundumHeater>().HasData(
                new CarborundumHeater
                {
                    CarborunbumHeatersId = 1,
                    Name = "КНМ-8*100*270",
                    WorkLength = 0.1,
                    Length = 0.27,
                    WorkDiameter = 0.008,
                    Diameter = 0.014,
                    WorkSurfaceArea = 2.51,
                    Resistance = 2.0
                },
                new CarborundumHeater
                {
                    CarborunbumHeatersId = 2,
                    Name = "КНМ-8*150*270",
                    WorkLength = 0.15,
                    Length = 0.27,
                    WorkDiameter = 0.008,
                    Diameter = 0.014,
                    WorkSurfaceArea = 3.77,
                    Resistance = 3.0
                },
                new CarborundumHeater
                {
                    CarborunbumHeatersId = 3,
                    Name = "КНМ-8*150*320",
                    WorkLength = 0.15,
                    Length = 0.32,
                    WorkDiameter = 0.008,
                    Diameter = 0.014,
                    WorkSurfaceArea = 3.77,
                    Resistance = 3.0
                },
                new CarborundumHeater
                {
                    CarborunbumHeatersId = 4,
                    Name = "КНМ-8*150*450",
                    WorkLength = 0.15,
                    Length = 0.42,
                    WorkDiameter = 0.008,
                    Diameter = 0.014,
                    WorkSurfaceArea = 3.77,
                    Resistance = 3.0
                },
                new CarborundumHeater
                {
                    CarborunbumHeatersId = 5,
                    Name = "КНМ-8*180*300",
                    WorkLength = 0.18,
                    Length = 0.30,
                    WorkDiameter = 0.008,
                    Diameter = 0.014,
                    WorkSurfaceArea = 4.52,
                    Resistance = 3.6
                },
                new CarborundumHeater
                {
                    CarborunbumHeatersId = 6,
                    Name = "КНМ-8*180*350",
                    WorkLength = 0.18,
                    Length = 0.35,
                    WorkDiameter = 0.008,
                    Diameter = 0.014,
                    WorkSurfaceArea = 4.52,
                    Resistance = 3.6
                },
                new CarborundumHeater
                {
                    CarborunbumHeatersId = 7,
                    Name = "КНМ-8*180*400",
                    WorkLength = 0.18,
                    Length = 0.40,
                    WorkDiameter = 0.008,
                    Diameter = 0.014,
                    WorkSurfaceArea = 4.52,
                    Resistance = 3.6
                },
                new CarborundumHeater
                {
                    CarborunbumHeatersId = 8,
                    Name = "КНМ-8*180*480",
                    WorkLength = 0.18,
                    Length = 0.48,
                    WorkDiameter = 0.008,
                    Diameter = 0.014,
                    WorkSurfaceArea = 4.52,
                    Resistance = 3.6
                },
                new CarborundumHeater
                {
                    CarborunbumHeatersId = 9,
                    Name = "КНМ-8*200*500",
                    WorkLength = 0.20,
                    Length = 0.50,
                    WorkDiameter = 0.008,
                    Diameter = 0.014,
                    WorkSurfaceArea = 5.03,
                    Resistance = 4.0
                },
                new CarborundumHeater
                {
                    CarborunbumHeatersId = 10,
                    Name = "КНМ-8*250*450",
                    WorkLength = 0.25,
                    Length = 0.45,
                    WorkDiameter = 0.008,
                    Diameter = 0.014,
                    WorkSurfaceArea = 6.28,
                    Resistance = 5.0
                },
                new CarborundumHeater
                {
                    CarborunbumHeatersId = 11,
                    Name = "КНМ-12*250*750",
                    WorkLength = 0.25,
                    Length = 0.75,
                    WorkDiameter = 0.012,
                    Diameter = 0.018,
                    WorkSurfaceArea = 9.42,
                    Resistance = 3.0
                },
                new CarborundumHeater
                {
                    CarborunbumHeatersId = 12,
                    Name = "КНМ-14*300*250",
                    WorkLength = 0.30,
                    Length = 0.80,
                    WorkDiameter = 0.014,
                    Diameter = 0.23,
                    WorkSurfaceArea = 13.20,
                    Resistance = 3.5
                }
            );
        }
    }
}
