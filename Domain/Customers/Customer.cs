using System;
using App.BespokedBikes.Domain.Common;

namespace App.BespokedBikes.Domain.Customers
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }    
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime StartDate { get; set; }
    }
}
