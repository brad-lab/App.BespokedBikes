using App.BespokedBikes.Application.Common;
using App.BespokedBikes.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.BespokedBikes.Application.Employees
{
    public class EmployeeValidator : IEmployeeValidator
    {
        private readonly IDatabaseService _database;
        public EmployeeValidator(IDatabaseService database) => _database = database;
        public async Task<ValidationResult> ValidateNoDuplicateAsync(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                return ValidationResult.Success;

            var fName = firstName.Trim().ToLowerInvariant();
            var lName = lastName.Trim().ToLowerInvariant();            

            var exists = await _database.Employees
                .AsNoTracking()
                .AnyAsync(p =>
                    EF.Functions.Like(p.FirstName.Trim().ToLower(), fName) &&
                    EF.Functions.Like(p.LastName.Trim().ToLower(), lName));

            if (exists)
                return new ValidationResult(false, "A salesperson with the same first name, and last name already exists.");

            return ValidationResult.Success;
        }
    }
}
