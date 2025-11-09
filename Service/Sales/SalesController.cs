using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using App.BespokedBikes.Application.Sales.Commands.CreateSale;
using App.BespokedBikes.Application.Sales.Queries.GetSaleDetail;
using App.BespokedBikes.Application.Sales.Queries.GetSalesList;

namespace App.BespokedBikes.Service.Sales
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IGetSalesListQuery _listQuery;
        private readonly IGetSaleDetailQuery _detailQuery;
        private readonly ICreateSaleCommand _createCommand;

        public SalesController(
            IGetSalesListQuery listQuery,
            IGetSaleDetailQuery detailQuery,
            ICreateSaleCommand createCommand)
        {
            _listQuery = listQuery;
            _detailQuery = detailQuery;
            _createCommand = createCommand;
        }

        [HttpGet]
        public IEnumerable<SalesListItemModel> Get()
        {
            return _listQuery.Execute();
        }

        [HttpGet("{id}")]
        public SaleDetailModel Get(int id)
        {
            return _detailQuery.Execute(id);
        }

        [HttpPost]
        public HttpResponseMessage Create(CreateSaleModel sale)
        {
            _createCommand.Execute(sale);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
