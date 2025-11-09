using App.BespokedBikes.Application.Employees.Queries.GetEmployeesList;

namespace App.BespokedBikes.Application.Employees.Queries.GetEmployeeById
{
    public interface IGetEmployeeByIdQuery
    {
        /// <summary>
        /// Returns the employee DTO for the given id or null if not found.
        /// </summary>
        EmployeeModel Execute(int id);
    }
}