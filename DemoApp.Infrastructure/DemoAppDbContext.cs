using DemoApp.Domain.Entities;
using DemoApp.Infrastructure.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DemoApp.Infrastructure
{
    public class DemoAppDbContext : DbContext
    {
        public DemoAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<IdName> Types { get; set; }

        public DbSet<T> TypeOf<T>() where T : IdName => this.Set<T>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfiguration).Assembly);

            SeedData.Seed(modelBuilder);
        }

    }
}
