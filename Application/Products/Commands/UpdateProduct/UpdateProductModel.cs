using System;

namespace App.BespokedBikes.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Style { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int QuantityOnHand { get; set; }
        public int CommissionPercentage { get; set; }
    }
}