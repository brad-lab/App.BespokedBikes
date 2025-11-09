namespace App.BespokedBikes.Application.Employees.Commands.UpdateEmployee
{
    public interface IUpdateEmployeeCommand
    {
        /// <summary>
        /// Updates an existing employee based on the provided model.
        /// </summary>
        void Execute(UpdateEmployeeModel model);
    }
}