using System;
using Microsoft.AspNetCore.Mvc;
using App.BespokedBikes.Application.Customers.Queries.GetCustomerList;

namespace App.BespokedBikes.Presentation.Customers
{
    public class CustomersController : Controller
    {
        private readonly IGetCustomersListQuery _query;

        public CustomersController(IGetCustomersListQuery query)
        {
            _query = query;
        }

        public ViewResult Index()
        {
            var customers = _query.Execute();

            return View(customers);
        }
    }
}