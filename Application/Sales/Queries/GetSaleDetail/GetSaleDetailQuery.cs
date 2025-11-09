using System;
using System.Collections.Generic;
using System.Linq;
using App.BespokedBikes.Application.Interfaces;

namespace App.BespokedBikes.Application.Sales.Queries.GetSaleDetail
{
    public class GetSaleDetailQuery
        : IGetSaleDetailQuery
    {
        private readonly IDatabaseService _database;

        public GetSaleDetailQuery(IDatabaseService database)
        {
            _database = database;
        }

        public SaleDetailModel Execute(int saleId)
        {
            var sale = _database.Sales
                .Where(p => p.Id == saleId)
                .Select(p => new SaleDetailModel()
                {
                    Id = p.Id, 
                    Date = p.Date,
                    CustomerName = String.Format("{ 0 } { 1 }", p.Customer.FirstName, p.Customer.LastName),
                    EmployeeName = String.Format("{ 0 } { 1 }", p.Employee.FirstName, p.Employee.LastName),
                    ProductName = p.Product.Name,
                    UnitPrice = p.UnitPrice,
                    Quantity = p.Quantity,
                    TotalPrice = p.TotalPrice
                })
                .Single();

            return sale;
        }
    }
}
