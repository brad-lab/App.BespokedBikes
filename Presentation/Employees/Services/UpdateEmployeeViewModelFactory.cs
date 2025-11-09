using App.BespokedBikes.Application.Employees.Commands.UpdateEmployee;
using App.BespokedBikes.Presentation.Employees.Models;

namespace App.BespokedBikes.Presentation.Employees.Services
{
    public class UpdateEmployeeViewModelFactory : IUpdateEmployeeViewModelFactory
    {
        public UpdateEmployeeViewModelFactory()
        {
        }

        public UpdateEmployeeViewModel Create()
        {
            var viewModel = new UpdateEmployeeViewModel();
            viewModel.Employee = new UpdateEmployeeModel();
            return viewModel;
        }
    }
}