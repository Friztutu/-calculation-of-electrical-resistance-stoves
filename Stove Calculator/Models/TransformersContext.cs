using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Models
{
    public class TransformersContext : DbContext
    {
        public DbSet<Transformers> Transformers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=transformers.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transformers>().HasData(
                new Transformers
                {
                    TransformersId = 1,
                    Name = "ЛАТР",
                    NumberOfPhases = 1,
                    MainsVoltage = [220],
                    Power = [2],
                    AdjustableVoltage = [220],
                    MinimumLoadCurrent = [9]
                },
                new Transformers
                {
                    TransformersId = 2,
                    Name = "РНО",
                    NumberOfPhases = 1,
                    MainsVoltage = [127, 220],
                    Power = [10],
                    AdjustableVoltage = [130, 250],
                    MinimumLoadCurrent = [40]
                },
                new Transformers
                {
                    TransformersId = 3,
                    Name = "TPI",
                    NumberOfPhases = 1,
                    MainsVoltage = [127, 220],
                    Power = [12],
                    AdjustableVoltage = [127, 220],
                    MinimumLoadCurrent = [70, 30]
                },
                new Transformers
                {
                    TransformersId = 4,
                    Name = "АОСК",
                    NumberOfPhases = 1,
                    MainsVoltage = [220, 380],
                    Power = [10, 25],
                    AdjustableVoltage = [220, 380],
                    MinimumLoadCurrent = [30, 60]
                },
                new Transformers
                {
                    TransformersId = 5,
                    Name = "АОМН",
                    NumberOfPhases = 1,
                    MainsVoltage = [127, 220],
                    Power = [10],
                    AdjustableVoltage = [130, 240],
                    MinimumLoadCurrent = [24, 40]
                },
                new Transformers
                {
                    TransformersId = 6,
                    Name = "МА",
                    NumberOfPhases = 1,
                    MainsVoltage = [220, 380],
                    Power = [52, 55, 68],
                    AdjustableVoltage = [380, 650],
                    MinimumLoadCurrent = [135, 250, 380, 600]
                },
                new Transformers
                {
                    TransformersId = 7,
                    Name = "АОМК",
                    NumberOfPhases = 1,
                    MainsVoltage = [220, 380],
                    Power = [100],
                    AdjustableVoltage = [220, 380],
                    MinimumLoadCurrent = [200]
                },
                new Transformers
                {
                    TransformersId = 8,
                    Name = "РНТ",
                    NumberOfPhases = 3,
                    MainsVoltage = [127, 220],
                    Power = [6, 12],
                    AdjustableVoltage = [127, 220],
                    MinimumLoadCurrent = [16, 32]
                },
                new Transformers
                {
                    TransformersId = 9,
                    Name = "ТС",
                    NumberOfPhases = 3,
                    MainsVoltage = [127, 220, 380],
                    Power = [10, 30],
                    AdjustableVoltage = [127, 220, 380],
                    MinimumLoadCurrent = [30, 40, 60, 100]
                },
                new Transformers
                {
                    TransformersId = 10,
                    Name = "РН",
                    NumberOfPhases = 3,
                    MainsVoltage = [220],
                    Power = [35],
                    AdjustableVoltage = [220],
                    MinimumLoadCurrent = [150]
                },
                new Transformers
                {
                    TransformersId = 11,
                    Name = "ТРЗ",
                    NumberOfPhases = 3,
                    MainsVoltage = [127, 220, 380],
                    Power = [100],
                    AdjustableVoltage = [127, 220, 380],
                    MinimumLoadCurrent = [100, 200, 300, 600]
                },
                new Transformers
                {
                    TransformersId = 12,
                    Name = "АИ",
                    NumberOfPhases = 3,
                    MainsVoltage = [220],
                    Power = [15, 23],
                    AdjustableVoltage = [20, 400],
                    MinimumLoadCurrent = [22, 33]
                },
                new Transformers
                {
                    TransformersId = 13,
                    Name = "АТСК",
                    NumberOfPhases = 3,
                    MainsVoltage = [220, 380],
                    Power = [25],
                    AdjustableVoltage = [220, 380],
                    MinimumLoadCurrent = [60]
                },
                new Transformers
                {
                    TransformersId = 14,
                    Name = "ТПРА",
                    NumberOfPhases = 3,
                    MainsVoltage = [380],
                    Power = [],
                    AdjustableVoltage = [114, 228, 456],
                    MinimumLoadCurrent = [40, 20, 10]
                },
                new Transformers
                {
                    TransformersId = 15,
                    Name = "ТПРБ",
                    NumberOfPhases = 3,
                    MainsVoltage = [380],
                    Power = [],
                    AdjustableVoltage = [29, 57],
                    MinimumLoadCurrent = [160, 80]
                },
                new Transformers
                {
                    TransformersId = 16,
                    Name = "ТПРB",
                    NumberOfPhases = 3,
                    MainsVoltage = [380],
                    Power = [],
                    AdjustableVoltage = [57, 114, 22],
                    MinimumLoadCurrent = [80, 40, 20, 10]
                }
            );
        }
    }
}
