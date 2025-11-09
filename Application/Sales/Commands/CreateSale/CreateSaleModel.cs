using System;
using System.Collections.Generic;
using System.Linq;

namespace App.BespokedBikes.Application.Sales.Commands.CreateSale
{
    public class CreateSaleModel
    {
        public int CustomerId { get; set; }

        public int EmployeeId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }        
    }
}
