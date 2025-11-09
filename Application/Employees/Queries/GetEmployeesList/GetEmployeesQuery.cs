using System;
using System.Collections.Generic;
using System.Linq;
using App.BespokedBikes.Application.Interfaces;

namespace App.BespokedBikes.Application.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQuery 
        : IGetEmployeesListQuery
    {
        private readonly IDatabaseService _database;

        public GetEmployeesListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<EmployeeModel> Execute()
        {
            var employees = _database.Employees
                .Select(p => new EmployeeModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Address = p.Address,
                    Phone = p.Phone,
                    StartDate = p.StartDate,
                    TerminationDate = p.TerminationDate,
                    Manager = p.Manager

                });               

            return employees.ToList();
        }
    }
}
