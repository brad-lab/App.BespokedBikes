using System;
using System.Collections.Generic;
using System.Linq;
using App.BespokedBikes.Application.Interfaces;

namespace App.BespokedBikes.Application.Sales.Queries.GetSalesList
{
    public class GetSalesListQuery 
        : IGetSalesListQuery
    {
        private readonly IDatabaseService _database;

        public GetSalesListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<SalesListItemModel> Execute()
        {
            var sales = _database.Sales
                .Select(p => new SalesListItemModel()
                {
                    Id = p.Id, 
                    Date = p.Date,
                    CustomerName = String.Format("{0} {1}", p.Customer.FirstName, p.Customer.LastName),
                    EmployeeName = String.Format("{0} {1}", p.Employee.FirstName, p.Employee.LastName),
                    ProductName = p.Product.Name,
                    UnitPrice = p.UnitPrice,
                    Quantity = p.Quantity,
                    TotalPrice = p.TotalPrice
                });

            return sales.ToList();
        }
    }
}
