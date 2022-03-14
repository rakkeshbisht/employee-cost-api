using EmployeeCostAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeCostAPI.DataContext
{
    internal class DependentConfiguration : IEntityTypeConfiguration<Dependent>
    {
        public void Configure(EntityTypeBuilder<Dependent> builder)
        {
            builder.HasKey(x => x.DependentId);
            builder.Property(x => x.Name);
            builder.Property(x => x.RelationShip);
        }
    }
}