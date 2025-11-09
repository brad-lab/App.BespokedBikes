using System;
using System.Collections.Generic;
using System.Linq;
using App.BespokedBikes.Domain.Customers;
using App.BespokedBikes.Domain.Employees;
using App.BespokedBikes.Domain.Products;
using App.BespokedBikes.Domain.Sales;

namespace App.BespokedBikes.Application.Sales.Commands.CreateSale.Factory
{
    public interface ISaleFactory
    {
        Sale Create(DateTime date, Customer customer, Employee employee, Product product, int quantity);
    }
}