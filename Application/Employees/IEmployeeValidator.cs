using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BespokedBikes.Application.Common;

namespace App.BespokedBikes.Application.Employees
{
    public interface IEmployeeValidator
    {
        Task<ValidationResult> ValidateNoDuplicateAsync(string firstName, string lastName);
    }
}
