using System;
using System.Collections.Generic;

namespace App.BespokedBikes.Application.Sales.Queries.GetSalesList
{
    public interface IGetSalesListQuery
    {
        // Optional date range filter. If a value is null, no filtering is applied for that bound.
        List<SalesListItemModel> Execute(DateTime? startDate = null, DateTime? endDate = null);
    }
}