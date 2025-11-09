using System;
using System.Linq;
using App.BespokedBikes.Application.Interfaces;
using App.BespokedBikes.Domain.Products;

namespace App.BespokedBikes.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IUpdateProductCommand
    {
        private readonly IDatabaseService _database;

        public UpdateProductCommand(IDatabaseService database)
        {
            _database = database;
        }

        public void Execute(UpdateProductModel model)
        {
            var product = _database.Products.SingleOrDefault(p => p.Id == model.Id);
            if (product == null)
                throw new InvalidOperationException($"Product with id {model.Id} not found.");

            // map updated values
            product.Name = model.Name;
            product.Manufacturer = model.Manufacturer;
            product.Style = model.Style;
            product.PurchasePrice = model.PurchasePrice;
            product.SalePrice = model.SalePrice;
            product.QuantityOnHand = model.QuantityOnHand;
            product.CommissionPercentage = model.CommissionPercentage;

            _database.Save();
        }
    }
}