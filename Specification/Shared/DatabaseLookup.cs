using System;
using System.Collections.Generic;
using System.Linq;
using App.BespokedBikes.Application.Interfaces;

namespace App.BespokedBikes.Specification.Shared
{
    public class DatabaseLookup
    {
        private readonly IDatabaseService _database;

        public DatabaseLookup(IDatabaseService database)
        {
            _database = database;
        }

        public int GetCustomerId(string name)
        {
            return _database.Customers
                .Single(p => p.LastName == name).Id;
        }

        public int GetEmployeeId(string name)
        {
            return _database.Employees
                .Single(p => p.FirstName == name).Id;
        }

        public int GetProductIdByName(string name)
        {
            return _database.Products
                .Single(p => p.Name == name).Id;
        }
    }
}
