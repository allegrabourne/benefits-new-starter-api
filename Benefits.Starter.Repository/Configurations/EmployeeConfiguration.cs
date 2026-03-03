using Benefits.Starter.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benefits.Starter.Repository.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.EmployeeNo)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasIndex(e => e.Email)
                .IsUnique();

            builder.HasIndex(e => e.EmployeeNo)
                .IsUnique();

            builder.OwnsOne(e => e.Address);
        }
    }
}