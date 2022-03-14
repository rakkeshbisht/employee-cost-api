using EmployeeCostAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeCostAPI.DataContext
{   
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.EmployeeId);

            builder.Property(x => x.Name);
            builder.Property(x => x.Role);
            builder.Property(x => x.Salary);

            builder.HasMany(x => x.Dependents);
        }
    }
}
