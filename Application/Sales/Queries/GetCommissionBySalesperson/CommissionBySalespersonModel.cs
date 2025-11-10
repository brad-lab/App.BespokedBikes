using System;

namespace App.BespokedBikes.Application.Sales.Queries.GetCommissionBySalesperson
{
    public class CommissionBySalespersonModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int SalesCount { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalCommission { get; set; }
    }
}