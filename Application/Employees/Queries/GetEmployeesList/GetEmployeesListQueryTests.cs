using System;
using System.Collections.Generic;
using System.Linq;
using Moq.AutoMock;
using Moq.EntityFrameworkCore;
using App.BespokedBikes.Application.Interfaces;
using App.BespokedBikes.Domain.Employees;
using NUnit.Framework;

namespace App.BespokedBikes.Application.Employees.Queries.GetEmployeesList
{
    [TestFixture]
    public class GetEmployeesListQueryTests
    {
        private GetEmployeesListQuery _query;
        private AutoMocker _mocker;
        private Employee _employee;

        private const int Id = 1;
        private const string Name = "Employee 1";

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();

            _employee = new Employee()
            {
                Id = Id,
                FirstName = Name
            };

            _mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Employees)
                .ReturnsDbSet(new List<Employee> { _employee });

            _query = _mocker.CreateInstance<GetEmployeesListQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnListOfEmployees()
        {
            var results = _query.Execute();

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.FirstName, Is.EqualTo(Name));
        }
    }
}
