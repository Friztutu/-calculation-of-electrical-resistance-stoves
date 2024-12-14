using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Models
{
    public class MetalHeatersContext : DbContext
    {
        public DbSet<MetalHeaters> MetalHeaters { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=metalheaters.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MetalHeaters>().HasData(
                new MetalHeaters
                {
                    Id = 1,
                    Name = "Проволочный, диаметром dн",
                    HeaterShape = "Линейная",
                    PlacementMethod = "Открытый",
                    J = 0.390
                },
                new MetalHeaters
                {
                    Id = 2,
                    Name = "Проволочный, диаметром dн",
                    HeaterShape = "Линейная",
                    PlacementMethod = "На полочке",
                    J = 0.370
                },
                new MetalHeaters
                {
                    Id = 3,
                    Name = "Проволочный, диаметром dн",
                    HeaterShape = "Линейная",
                    PlacementMethod = "В пазу",
                    J = 0.340
                },
                new MetalHeaters
                {
                    Id = 4,
                    Name = "Проволочный, диаметром dн",
                    HeaterShape = "Спиральная с шагом t = 2dн диаметром D",
                    PlacementMethod = "Открытый",
                    J = 0.555
                },
                new MetalHeaters
                {
                    Id = 5,
                    Name = "Проволочный, диаметром dн",
                    HeaterShape = "Спиральная с шагом t = 2dн диаметром D",
                    PlacementMethod = "Открытый на трубке",
                    J = 0.550
                },
                new MetalHeaters
                {
                    Id = 6,
                    Name = "Проволочный, диаметром dн",
                    HeaterShape = "Спиральная с шагом t = 2dн диаметром D",
                    PlacementMethod = "На полочке",
                    J = 0.545
                },
                new MetalHeaters
                {
                    Id = 7,
                    Name = "Проволочный, диаметром dн",
                    HeaterShape = "Спиральная с шагом t = 2dн диаметром D",
                    PlacementMethod = "В пазу",
                    J = 0.540
                },
                new MetalHeaters
                {
                    Id = 8,
                    Name = "Проволочный, диаметром dн",
                    HeaterShape = "Зигзаг с шагом t = 5.5dн высотой H",
                    PlacementMethod = "Открытый",
                    J = 0.550
                },
                new MetalHeaters
                {
                    Id = 9,
                    Name = "Проволочный, диаметром dн",
                    HeaterShape = "Зигзаг с шагом t = 5.5dн высотой H",
                    PlacementMethod = "На полочке",
                    J = 0.540
                },
                new MetalHeaters
                {
                    Id = 10,
                    Name = "Проволочный, диаметром dн",
                    HeaterShape = "Зигзаг с шагом t = 5.5dн высотой H",
                    PlacementMethod = "В пазу",
                    J = 0.535
                },
                new MetalHeaters
                {
                    Id = 11,
                    Name = "Ленточный, толщиной aн, шириной bн",
                    HeaterShape = "Линенйная",
                    PlacementMethod = "Открытый",
                    J = 0.500
                },
                new MetalHeaters
                {
                    Id = 12,
                    Name = "Ленточный, толщиной aн, шириной bн",
                    HeaterShape = "Линенйная",
                    PlacementMethod = "На полочке",
                    J = 0.450
                },
                new MetalHeaters
                {
                    Id = 13,
                    Name = "Ленточный, толщиной aн, шириной bн",
                    HeaterShape = "Линенйная",
                    PlacementMethod = "В пазу",
                    J = 0.350
                },
                new MetalHeaters
                {
                    Id = 14,
                    Name = "Ленточный, толщиной aн, шириной bн",
                    HeaterShape = "Зигзаг с шагом t = 5.5maн высотой H",
                    PlacementMethod = "Открытый",
                    J = 0.505
                },
                new MetalHeaters
                {
                    Id = 15,
                    Name = "Ленточный, толщиной aн, шириной bн",
                    HeaterShape = "Зигзаг с шагом t = 5.5maн высотой H",
                    PlacementMethod = "На полочке",
                    J = 0.470
                },
                new MetalHeaters
                {
                    Id = 16,
                    Name = "Ленточный, толщиной aн, шириной bн",
                    HeaterShape = "Зигзаг с шагом t = 5.5maн высотой H",
                    PlacementMethod = "В пазу",
                    J = 0.535
                }
            );
        }
    }
}
