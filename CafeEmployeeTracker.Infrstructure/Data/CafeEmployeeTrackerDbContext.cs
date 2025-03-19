using CafeEmployeeTracker.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Infrstructure.Data
{
    public class CafeEmployeeTrackerDbContext(DbContextOptions<CafeEmployeeTrackerDbContext> dbContextOPtion) : DbContext(dbContextOPtion)
    {
        public DbSet<Cafe> Cafes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeCafe> EmployeeCafes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example configuration
            modelBuilder.Entity<EmployeeCafe>()
                .ToTable("EmployeeCafes");
        }
    }
}
