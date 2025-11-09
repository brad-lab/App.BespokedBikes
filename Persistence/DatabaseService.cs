using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using App.BespokedBikes.Application.Interfaces;
using App.BespokedBikes.Domain.Customers;
using App.BespokedBikes.Domain.Employees;
using App.BespokedBikes.Domain.Products;
using App.BespokedBikes.Domain.Sales;
using App.BespokedBikes.Persistence.Customers;
using App.BespokedBikes.Persistence.Employees;
using App.BespokedBikes.Persistence.Products;
using App.BespokedBikes.Persistence.Sales;


namespace App.BespokedBikes.Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        private readonly IConfiguration _configuration;

        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;

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
            var connectionString = _configuration.GetConnectionString("App.BespokedBikes");

            optionsBuilder.UseSqlServer(connectionString);
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
