using System;
using System.Collections.Generic;
using System.Linq;

namespace App.BespokedBikes.Application.Sales.Queries.GetSaleDetail
{
    public interface IGetSaleDetailQuery
    {
        SaleDetailModel Execute(int id);
    }
}