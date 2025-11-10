using System;
using System.Collections.Generic;
using System.Linq;
using App.BespokedBikes.Application.Interfaces;

namespace App.BespokedBikes.Application.Sales.Queries.GetSalesList
{
    public class GetSalesListQuery : IGetSalesListQuery
    {
        private readonly IDatabaseService _database;

        public GetSalesListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<SalesListItemModel> Execute(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _database.Sales.AsQueryable();

            if (startDate.HasValue)
            {
                // include from midnight of start date
                var s = startDate.Value.Date;
                query = query.Where(x => x.Date >= s);
            }

            if (endDate.HasValue)
            {
                // include up to end of endDate (inclusive)
                var e = endDate.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(x => x.Date <= e);
            }

            var sales = query
                .Select(p => new SalesListItemModel()
                {
                    Id = p.Id,
                    Date = p.Date,
                    CustomerName = String.Format("{0} {1}", p.Customer.FirstName, p.Customer.LastName),
                    EmployeeName = String.Format("{0} {1}", p.Employee.FirstName, p.Employee.LastName),
                    ProductName = p.Product.Name,
                    UnitPrice = p.UnitPrice,
                    Quantity = p.Quantity,
                    TotalPrice = p.TotalPrice,
                    SalesCommission = p.Product != null ? p.TotalPrice * (p.Product.CommissionPercentage / 100m) : 0m
                });

            return sales.ToList();
        }
    }
}
