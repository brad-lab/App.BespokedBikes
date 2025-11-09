using App.BespokedBikes.Application.Interfaces;
using App.BespokedBikes.Application.Products.Queries.GetProductsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BespokedBikes.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IGetProductByIdQuery
    {
        private readonly IDatabaseService _database;
        public GetProductByIdQuery(IDatabaseService database)
        {
            _database = database;
        }
        public ProductModel Execute(int id)
        {
            var e = _database.Products.SingleOrDefault(x => x.Id == id);    

            if (e == null) return null;

            return new ProductModel
            {
                Id = e.Id,
                Name = e.Name,
                Manufacturer = e.Manufacturer,
                Style = e.Style,
                PurchasePrice = e.PurchasePrice,
                SalePrice = e.SalePrice,
                QuantityOnHand = e.QuantityOnHand,
                CommissionPercentage = e.CommissionPercentage
            };
        }
    }
}
