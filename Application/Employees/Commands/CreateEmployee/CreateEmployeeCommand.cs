using App.BespokedBikes.Application.Employees.Commands.CreateEmployee.Factory;
using App.BespokedBikes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BespokedBikes.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : ICreateEmployeeCommand
    {
        private readonly IEmployeeFactory _factory;
        private readonly IDatabaseService _database;
        public CreateEmployeeCommand(
            IEmployeeFactory factory,
            IDatabaseService database
            )
        {
            _factory = factory;
            _database = database;
        }
        public void Execute(CreateEmployeeModel model)
        {
            var employee = _factory.Create(
                model.FirstName,
                model.LastName,
                model.Address,
                model.Phone,
                model.StartDate,
                model.TerminationDate,
                model.Manager);

            _database.Employees.Add(employee);
            _database.Save();
        }
    }
}
