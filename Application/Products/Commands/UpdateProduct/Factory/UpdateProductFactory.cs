using App.BespokedBikes.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BespokedBikes.Application.Products.Commands.UpdateProduct.Factory
{
    public class UpdateProductFactory : IUpdateProductFactory
    {
        public Product Update(int id, string name, string manufacturer, string style, decimal purchasePrice, decimal salePrice, int quantityOnHand, double commissionPercentage)
        {
            return new Product
            {
                Id = id,
                Name = name,
                Manufacturer = manufacturer,
                Style = style,
                PurchasePrice = purchasePrice,
                SalePrice = salePrice,
                QuantityOnHand = quantityOnHand,
                CommissionPercentage = (int)commissionPercentage
            };           
        }
    }
}
