using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Models
{
    public class ElectricMachinesContext : DbContext
    {
        public DbSet<ElectricMachines> ElectricMachines { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=electricmachines.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ElectricMachines>().HasData(
                new ElectricMachines 
                { 
                    ElectricMachinesId = 1,
                    Name = "А-3161",
                    NumberOfPhase = 1,
                    Voltage = 220,
                    MaximumLoadCurrent = [15, 20, 25, 30, 40, 50]
                },
                new ElectricMachines
                {
                    ElectricMachinesId = 2,
                    Name = "АЕ-1031",
                    NumberOfPhase = 1,
                    Voltage = 380,
                    MaximumLoadCurrent = [16, 25]
                },
                new ElectricMachines
                {
                    ElectricMachinesId = 3,
                    Name = "АЕ-2016",
                    NumberOfPhase = 3,
                    Voltage = 380,
                    MaximumLoadCurrent = [5, 10, 12, 15, 20, 30, 40, 50, 60, 80, 100]
                },
                new ElectricMachines
                {
                    ElectricMachinesId = 4,
                    Name = "АП-50",
                    NumberOfPhase = 3,
                    Voltage = 380,
                    MaximumLoadCurrent = [4, 6, 10, 16, 25, 40, 50]
                },
                new ElectricMachines
                {
                    ElectricMachinesId = 5,
                    Name = "А-3161",
                    NumberOfPhase = 3,
                    Voltage = 380,
                    MaximumLoadCurrent = [20, 30, 40, 50]
                },
                new ElectricMachines
                {
                    ElectricMachinesId = 6,
                    Name = "А-31",
                    NumberOfPhase = 3,
                    Voltage = 380,
                    MaximumLoadCurrent = [100, 150, 200, 300, 400, 600]
                }
            );
        }
    }
}
