using System;
using System.Collections.Generic;
using System.Linq;
using App.BespokedBikes.Application.Interfaces;

namespace App.BespokedBikes.Application.Sales.Queries.GetCommissionBySalesperson
{
    public class GetCommissionBySalespersonQuery : IGetCommissionBySalespersonQuery
    {
        private readonly IDatabaseService _database;

        public GetCommissionBySalespersonQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<CommissionBySalespersonModel> Execute(int quarter, int year)
        {
            var (start, end) = GetQuarterRange(quarter, year);

            var query = _database.Sales
                .Where(s => s.Date >= start && s.Date <= end);

            var grouped = query
                .GroupBy(s => new { s.Employee.Id, s.Employee.FirstName, s.Employee.LastName })
                .Select(g => new CommissionBySalespersonModel
                {
                    EmployeeId = g.Key.Id,
                    EmployeeName = string.Concat(g.Key.FirstName, " ", g.Key.LastName),
                    SalesCount = g.Count(),
                    TotalSales = g.Sum(x => x.TotalPrice),
                    // compute commission using Product.CommissionPercentage (int as percent)
                    TotalCommission = g.Sum(x => x.Product != null ? x.TotalPrice * (x.Product.CommissionPercentage / 100m) : 0m)
                })
                .OrderByDescending(x => x.TotalCommission);

            return grouped.ToList();
        }

        private static (DateTime start, DateTime end) GetQuarterRange(int quarter, int year)
        {
            switch (quarter)
            {
                case 1:
                    return (new DateTime(year, 1, 1), new DateTime(year, 3, 31, 23, 59, 59));
                case 2:
                    return (new DateTime(year, 4, 1), new DateTime(year, 6, 30, 23, 59, 59));
                case 3:
                    return (new DateTime(year, 7, 1), new DateTime(year, 9, 30, 23, 59, 59));
                case 4:
                default:
                    return (new DateTime(year, 10, 1), new DateTime(year, 12, 31, 23, 59, 59));
            }
        }
    }
}