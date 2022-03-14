using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeCostAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeCostAPI.DataContext
{
    public class EmployeeDbContext : DbContext
    {

        public EmployeeDbContext()
        {

        }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Dependent> Dependents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new DependentConfiguration());

            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee { EmployeeId = 102, Name = "Amir", Role = "Software Engineer", Salary = 2000 },
            //    new Employee { EmployeeId = 103, Name = "Ralf", Role = "Sr. Software Engineer", Salary = 2000 },
            //    new Employee { EmployeeId = 104, Name = "Mike", Role = "Staff Software Engineer", Salary = 2000 });

            
        }
    }
}
