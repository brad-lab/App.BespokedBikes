using App.BespokedBikes.Application.Employees.Commands.CreateEmployee;
using App.BespokedBikes.Presentation.Employees.Models;


namespace App.BespokedBikes.Presentation.Employees.Services
{
    public class CreateEmployeeViewModelFactory : ICreateEmployeeViewModelFactory
    {
        public CreateEmployeeViewModelFactory()
        {
        }
        public CreateEmployeeViewModel Create()
        {
            var viewModel = new CreateEmployeeViewModel();

            viewModel.Employee = new CreateEmployeeModel();

            return viewModel;
        }
    }
}
