using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Models
{
    public class MolybdenumHeatersContext : DbContext
    {
        public DbSet<MolybdenumHeaters> MolybdenumHeaters { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=molybdenumheaters.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MolybdenumHeaters>().HasData(
                new MolybdenumHeaters { 
                    MolybdenumHeatersId = 1,
                    Name = "ДМ-180*250",
                    WorkLength = 0.180,
                    ExpandedWorkLength = 0.39,
                    Length = 0.25,
                    WorkSurfaceArea = 7.35
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 2,
                    Name = "ДМ-180*400",
                    WorkLength = 0.180,
                    ExpandedWorkLength = 0.39,
                    Length = 0.40,
                    WorkSurfaceArea = 7.35
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 3,
                    Name = "ДМ-250*250",
                    WorkLength = 0.250,
                    ExpandedWorkLength = 0.53,
                    Length = 0.25,
                    WorkSurfaceArea = 9.99
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 4,
                    Name = "ДМ-250*400",
                    WorkLength = 0.250,
                    ExpandedWorkLength = 0.53,
                    Length = 0.40,
                    WorkSurfaceArea = 9.99
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 5,
                    Name = "ДМ-315*250",
                    WorkLength = 0.315,
                    ExpandedWorkLength = 0.66,
                    Length = 0.25,
                    WorkSurfaceArea = 12.44
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 6,
                    Name = "ДМ-315*400",
                    WorkLength = 0.315,
                    ExpandedWorkLength = 0.66,
                    Length = 0.40,
                    WorkSurfaceArea = 12.44
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 7,
                    Name = "ДМ-315*500",
                    WorkLength = 0.315,
                    ExpandedWorkLength = 0.66,
                    Length = 0.50,
                    WorkSurfaceArea = 12.44
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 8,
                    Name = "ДМ-400*250",
                    WorkLength = 0.40,
                    ExpandedWorkLength = 0.83,
                    Length = 0.40,
                    WorkSurfaceArea = 15.64
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 9,
                    Name = "ДМ-400*400",
                    WorkLength = 0.40,
                    ExpandedWorkLength = 0.83,
                    Length = 0.40,
                    WorkSurfaceArea = 15.64
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 10,
                    Name = "ДМ-400*500",
                    WorkLength = 0.40,
                    ExpandedWorkLength = 0.83,
                    Length = 0.50,
                    WorkSurfaceArea = 15.64
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 11,
                    Name = "ДМ-500*250",
                    WorkLength = 0.50,
                    ExpandedWorkLength = 1.03,
                    Length = 0.25,
                    WorkSurfaceArea = 19.42
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 12,
                    Name = "ДМ-500*400",
                    WorkLength = 0.50,
                    ExpandedWorkLength = 1.03,
                    Length = 0.40,
                    WorkSurfaceArea = 19.42
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 13,
                    Name = "ДМ-500*500",
                    WorkLength = 0.50,
                    ExpandedWorkLength = 1.03,
                    Length = 0.50,
                    WorkSurfaceArea = 19.42
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 14,
                    Name = "ДМ-630*250",
                    WorkLength = 0.63,
                    ExpandedWorkLength = 1.29,
                    Length = 0.25,
                    WorkSurfaceArea = 24.32
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 15,
                    Name = "ДМ-630*400",
                    WorkLength = 0.63,
                    ExpandedWorkLength = 1.29,
                    Length = 0.40,
                    WorkSurfaceArea = 24.32
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 16,
                    Name = "ДМ-630*500",
                    WorkLength = 0.63,
                    ExpandedWorkLength = 1.29,
                    Length = 0.50,
                    WorkSurfaceArea = 24.32
                },
                new MolybdenumHeaters
                {
                    MolybdenumHeatersId = 17,
                    Name = "ДМ-800*700",
                    WorkLength = 0.83,
                    ExpandedWorkLength = 1.63,
                    Length = 0.70,
                    WorkSurfaceArea = 30.73
                }
            );
        }
    }
}
