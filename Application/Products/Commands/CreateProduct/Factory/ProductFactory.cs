using App.BespokedBikes.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BespokedBikes.Application.Products.Commands.CreateProduct.Factory
{
    public class ProductFactory: IProductFactory
    {
        public Product Create(string name, string manufacturer, string style, decimal purchasePrice, decimal salePrice, int quantityOnHand, int commissionPercentage)
        {
            var product = new Product();
            product.Name = name;
            product.Manufacturer = manufacturer;
            product.Style = style;
            product.PurchasePrice = purchasePrice;
            product.SalePrice = salePrice;
            product.QuantityOnHand = quantityOnHand;
            product.CommissionPercentage = commissionPercentage;
            return product;
        }
    }
}
