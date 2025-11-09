using App.BespokedBikes.Application.Interfaces;
using App.BespokedBikes.Application.Products.Commands.CreateProduct.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BespokedBikes.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : ICreateProductCommand
    {
        private readonly IDatabaseService _database;
        private readonly IProductFactory _factory;
        public CreateProductCommand(
            IDatabaseService database,
            IProductFactory factory)
        {
            _database = database;
            _factory = factory;
        }
        public void Execute(CreateProductModel model)
        {
            var product = _factory.Create(
                model.Name,
                model.Manufacturer,
                model.Style,
                model.PurchasePrice,
                model.SalePrice,
                model.QuantityOnHand,
                model.CommissionPercentage);

            _database.Products.Add(product);    
            _database.Save();
        }
    }
}
