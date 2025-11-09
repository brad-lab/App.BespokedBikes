using System;
using System.Collections.Generic;
using System.Linq;
using App.BespokedBikes.Domain.Customers;
using App.BespokedBikes.Domain.Employees;
using App.BespokedBikes.Domain.Products;
using App.BespokedBikes.Domain.Sales;

namespace App.BespokedBikes.Application.Sales.Commands.CreateSale.Factory
{
    public class SaleFactory : ISaleFactory
    {
        public Sale Create(DateTime date, Customer customer, Employee employee, Product product, int quantity)
        {
            var sale = new Sale();

            sale.Date = date;

            sale.Customer = customer;

            sale.Employee = employee;

            sale.Product = product;

            sale.UnitPrice = sale.Product.SalePrice;

            sale.Quantity = quantity;

            // Note: Total price is calculated in domain logic

            return sale;
        }
    }
}
