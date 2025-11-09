using App.BespokedBikes.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BespokedBikes.Application.Products.Commands.CreateProduct.Factory
{
    public interface IProductFactory
    {
        Product Create(string name, string manufacturer, string style, decimal purchasePrice, decimal salePrice, int quantityOnHand, int commissionPercentage);
    }
}
