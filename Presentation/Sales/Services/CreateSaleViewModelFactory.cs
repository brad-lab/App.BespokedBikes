using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using App.BespokedBikes.Application.Customers.Queries.GetCustomerList;
using App.BespokedBikes.Application.Employees.Queries.GetEmployeesList;
using App.BespokedBikes.Application.Products.Queries.GetProductsList;
using App.BespokedBikes.Application.Sales.Commands.CreateSale;
using App.BespokedBikes.Presentation.Sales.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.BespokedBikes.Presentation.Sales.Services
{
    public class CreateSaleViewModelFactory : ICreateSaleViewModelFactory
    {
        private readonly IGetCustomersListQuery _customersQuery;
        private readonly IGetEmployeesListQuery _employeesQuery;
        private readonly IGetProductsListQuery _productsQuery;

        public CreateSaleViewModelFactory(
            IGetCustomersListQuery customersQuery,
            IGetEmployeesListQuery employeesQuery,
            IGetProductsListQuery productsQuery)
        {
            _customersQuery = customersQuery;
            _employeesQuery = employeesQuery;
            _productsQuery = productsQuery;
        }

        public CreateSaleViewModel Create()
        {
            var employees = _employeesQuery.Execute();

            var customers = _customersQuery.Execute();

            var products = _productsQuery.Execute();

            var viewModel = new CreateSaleViewModel();

            viewModel.Employees = employees
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = String.Format("{0} {1}", p.FirstName, p.LastName)
                })
                .ToList();

            viewModel.Customers = customers
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = String.Format("{0} {1}", p.FirstName, p.LastName)    
                })
                .ToList();

            viewModel.Products = products
                .Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.Name + " ($" + p.SalePrice + ")"
                })
                .ToList();

            // default date to today so the form shows today's date
            viewModel.Sale = new CreateSaleModel
            {
                Date = DateTime.Today
            };

            return viewModel;
        }
    }
}