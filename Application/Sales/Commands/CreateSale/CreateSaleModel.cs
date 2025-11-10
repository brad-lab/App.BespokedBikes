using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace App.BespokedBikes.Application.Sales.Commands.CreateSale
{
    public class CreateSaleModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please select a customer.")]
        public int CustomerId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a salesperson.")]
        public int EmployeeId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a product.")]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        // optional: allow explicit date (already added previously)
        public DateTime Date { get; set; }        
    }
}
