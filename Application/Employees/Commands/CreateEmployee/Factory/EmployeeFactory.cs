using App.BespokedBikes.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BespokedBikes.Application.Employees.Commands.CreateEmployee.Factory
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public Employee Create(string firstName, string lastName, string address, string phone, DateTime startDate, DateTime? terminationDate, string manager)
        {
            var employee = new Employee();
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Address = address;
            employee.Phone = phone;
            employee.StartDate = startDate;
            employee.TerminationDate = terminationDate;
            employee.Manager = manager;
            return employee;

        }
    }
}
