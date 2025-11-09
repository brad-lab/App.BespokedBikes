using System;
using App.BespokedBikes.Domain.Employees;

namespace App.BespokedBikes.Application.Employees.Commands.UpdateEmployee.Factory
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public Employee Update(int id, string firstName, string lastName, string address, string phone, DateTime startDate, DateTime? terminationDate, string manager)
        {
            return new Employee
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Phone = phone,
                StartDate = startDate,
                TerminationDate = terminationDate,
                Manager = manager
            };
        }
    }
}