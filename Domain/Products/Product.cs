using System;
using App.BespokedBikes.Domain.Common;

namespace App.BespokedBikes.Domain.Products
{
    public class Product : IEntity
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
