using App.BespokedBikes.Application.Products.Commands.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BespokedBikes.Application.Employees.Commands.CreateEmployee
{
    public interface ICreateEmployeeCommand
    {
        void Execute(CreateEmployeeModel model);

    }
}
