using Microsoft.EntityFrameworkCore;
using App.BespokedBikes.Domain.Customers;
using App.BespokedBikes.Domain.Employees;
using App.BespokedBikes.Domain.Products;
using App.BespokedBikes.Domain.Sales;

namespace App.BespokedBikes.Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<Customer> Customers { get; set; }

        DbSet<Employee> Employees { get; set; }
        
        DbSet<Product> Products { get; set; }
        
        DbSet<Sale> Sales { get; set; }

        void Save();
    }
}