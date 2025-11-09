using App.BespokedBikes.Application.Interfaces;
using App.BespokedBikes.Domain.Customers;
using App.BespokedBikes.Domain.Employees;
using App.BespokedBikes.Domain.Products;
using App.BespokedBikes.Domain.Sales;
using App.BespokedBikes.Persistence.Customers;
using App.BespokedBikes.Persistence.Employees;
using App.BespokedBikes.Persistence.Products;
using App.BespokedBikes.Persistence.Sales;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BespokedBikes.Specification.Shared
{
    public class MockDatabaseService : DbContext, IDatabaseService
    {
        public MockDatabaseService(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "App.BespokedBikesInMemory");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new CustomerConfiguration().Configure(builder.Entity<Customer>());
            new EmployeeConfiguration().Configure(builder.Entity<Employee>());
            new ProductConfiguration().Configure(builder.Entity<Product>());
            new SaleConfiguration().Configure(builder.Entity<Sale>());
        }
    }
}
