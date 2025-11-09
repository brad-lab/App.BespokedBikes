using App.BespokedBikes.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BespokedBikes.Application.Products.Commands.UpdateProduct.Factory
{
    internal interface IUpdateProductFactory
    {
        Product Update(int id, string name, string manufacturer, string style, decimal purchasePrice, decimal salePrice, int quantityOnHand, double commissionPercentage);
    }
}
