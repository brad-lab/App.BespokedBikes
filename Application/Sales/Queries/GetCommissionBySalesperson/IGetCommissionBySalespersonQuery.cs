using System;
using System.Collections.Generic;

namespace App.BespokedBikes.Application.Sales.Queries.GetCommissionBySalesperson
{
    public interface IGetCommissionBySalespersonQuery
    {
        // quarter: 1=Jan-Mar, 2=Apr-Jun, 3=Jul-Sep, 4=Oct-Dec
        List<CommissionBySalespersonModel> Execute(int quarter, int year);
    }
}