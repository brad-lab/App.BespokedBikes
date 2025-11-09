using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using App.BespokedBikes.Application.Customers.Queries.GetCustomerList;

namespace App.BespokedBikes.Service.Customers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IGetCustomersListQuery _query;

        public CustomersController(IGetCustomersListQuery query)
        {
            _query = query;
        }

        [HttpGet]
        public IEnumerable<CustomerModel> Get()
        {
            return _query.Execute();
        }
    }
}