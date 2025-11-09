using System.Collections.Generic;

namespace App.BespokedBikes.Application.Employees.Queries.GetEmployeesList
{
    public interface IGetEmployeesListQuery
    {
        List<EmployeeModel> Execute();
    }
}