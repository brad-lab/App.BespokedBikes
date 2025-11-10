using System;
using System.Collections.Generic;
using App.BespokedBikes.Domain.Common;
using App.BespokedBikes.Domain.Customers;
using App.BespokedBikes.Domain.Employees;
using App.BespokedBikes.Domain.Products;

namespace App.BespokedBikes.Domain.Sales
{
    public class Sale : IEntity
    {
        private int _quantity;
        private decimal _totalPrice;
        private decimal _unitPrice;

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public Product Product { get; set; }

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                _unitPrice = value;

                UpdateTotalPrice();
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                
                UpdateTotalPrice();
            }
        }

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            private set { _totalPrice = value; }
        }

        // Read-only computed property for the sales commission.
        // Uses the product's CommissionPercentage (int) as a percentage.
        public decimal SalesCommission
        {
            get
            {
                if (Product == null) return 0m;
                return TotalPrice * (Product.CommissionPercentage / 100m);
            }
        }

        private void UpdateTotalPrice()
        {
            _totalPrice = _unitPrice * _quantity;
        }
    }
}
