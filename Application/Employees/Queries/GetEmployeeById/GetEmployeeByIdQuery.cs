using System.Linq;
using App.BespokedBikes.Application.Interfaces;
using App.BespokedBikes.Application.Employees.Queries.GetEmployeesList;

namespace App.BespokedBikes.Application.Employees.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery : IGetEmployeeByIdQuery
    {
        private readonly IDatabaseService _database;

        public GetEmployeeByIdQuery(IDatabaseService database)
        {
            _database = database;
        }

        public EmployeeModel Execute(int id)
        {
            var e = _database.Employees.SingleOrDefault(x => x.Id == id);
            if (e == null) return null;

            return new EmployeeModel
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Address = e.Address,
                Phone = e.Phone,
                StartDate = e.StartDate,
                TerminationDate = e.TerminationDate,
                Manager = e.Manager
            };
        }
    }
}