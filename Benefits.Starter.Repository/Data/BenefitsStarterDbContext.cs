using Benefits.Starter.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benefits.Starter.Repository.Data
{
    public class BenefitsStarterDbContext : DbContext
    {
        public BenefitsStarterDbContext(DbContextOptions<BenefitsStarterDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees => Set<Employee>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BenefitsStarterDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
