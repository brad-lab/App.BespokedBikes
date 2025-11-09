using App.BespokedBikes.Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BespokedBikes.Application.Employees.Commands.CreateEmployee.Factory
{
    public interface IEmployeeFactory
    {
        Employee Create(string firstName, string lastName, string address, string phone, DateTime startDate, DateTime? terminationDate, string manager);
    }
}
