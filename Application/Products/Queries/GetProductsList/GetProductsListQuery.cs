using System;
using System.Collections.Generic;
using System.Linq;
using App.BespokedBikes.Application.Interfaces;

namespace App.BespokedBikes.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery 
        : IGetProductsListQuery
    {
        private readonly IDatabaseService _database;

        public GetProductsListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<ProductModel> Execute()
        {
            var products = _database.Products
                .Select(p => new ProductModel
                {
                    Id = p.Id, 
                    Name = p.Name,
                    Manufacturer = p.Manufacturer,
                    Style = p.Style,
                    PurchasePrice = p.PurchasePrice,
                    SalePrice = p.SalePrice,
                    QuantityOnHand = p.QuantityOnHand,
                    CommissionPercentage = p.CommissionPercentage

                });

            return products.ToList();
        }
    }
}
