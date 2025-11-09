using System;
using System.Linq;
using App.BespokedBikes.Application.Interfaces;
using App.BespokedBikes.Domain.Employees;

namespace App.BespokedBikes.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IUpdateEmployeeCommand
    {
        private readonly IDatabaseService _database;

        public UpdateEmployeeCommand(IDatabaseService database)
        {
            _database = database;
        }

        public void Execute(UpdateEmployeeModel model)
        {
            var employee = _database.Employees.SingleOrDefault(e => e.Id == model.Id);
            if (employee == null)
                throw new InvalidOperationException($"Employee with id {model.Id} not found.");

            // map updated values
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.Address = model.Address;
            employee.Phone = model.Phone;
            employee.StartDate = model.StartDate;
            employee.TerminationDate = model.TerminationDate;
            employee.Manager = model.Manager;

            _database.Save();
        }
    }
}