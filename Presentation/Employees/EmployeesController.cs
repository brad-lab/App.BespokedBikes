using App.BespokedBikes.Application.Employees;
using App.BespokedBikes.Application.Employees.Commands.CreateEmployee;
using App.BespokedBikes.Application.Employees.Commands.UpdateEmployee;
using App.BespokedBikes.Application.Employees.Queries.GetEmployeeById;
using App.BespokedBikes.Application.Employees.Queries.GetEmployeesList;
using App.BespokedBikes.Presentation.Employees.Models;
using App.BespokedBikes.Presentation.Employees.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.BespokedBikes.Presentation.Employees
{
    [Route("employees")]
    public class EmployeesController : Controller
    {
        private readonly IGetEmployeesListQuery _query;
        private readonly ICreateEmployeeViewModelFactory _factory;
        private readonly ICreateEmployeeCommand _createcommand;
        private readonly IEmployeeValidator _employeeValidator;

        // new dependencies for edit
        private readonly IGetEmployeeByIdQuery _getById;
        private readonly IUpdateEmployeeCommand _updateCommand;        
        private readonly IUpdateEmployeeViewModelFactory _updateFactory;

        public EmployeesController(IGetEmployeesListQuery query,
                                    ICreateEmployeeViewModelFactory factory,
                                    ICreateEmployeeCommand createcommand,
                                    IEmployeeValidator employeeValidator,
                                    IGetEmployeeByIdQuery getById,
                                    IUpdateEmployeeCommand updateCommand,
                                    IUpdateEmployeeViewModelFactory updateFactory)
        {
            _query = query;
            _factory = factory;
            _createcommand = createcommand;
            _employeeValidator = employeeValidator;
            _getById = getById;
            _updateCommand = updateCommand;            
            _updateFactory = updateFactory;
        }
        [Route("index")]
        public ViewResult Index()
        {
            var employees = _query.Execute();

            return View(employees);
        }

        [Route("create")]
        public ViewResult Create()
        {
            var viewModel = _factory.Create();

            return View(viewModel);
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var model = viewModel.Employee;

            // Application-layer validation
            var validation = await _employeeValidator.ValidateNoDuplicateAsync(model.FirstName, model.LastName);
            if (!validation.IsValid)
            {
                ModelState.AddModelError(string.Empty, validation.ErrorMessage);
                return View(viewModel);
            }

            _createcommand.Execute(model);

            return RedirectToAction("index", "employees");
        }

        // GET: /employees/edit/{id}
        [HttpGet]
        [Route("edit")]
        public IActionResult Edit(int id)
        {
            var employeeDto = _getById.Execute(id);
            if (employeeDto == null)
                return NotFound();

            // Use update factory to create the VM for editing
            var vm = _updateFactory.Create();
            vm.Employee.Id = employeeDto.Id;
            vm.Employee.FirstName = employeeDto.FirstName;
            vm.Employee.LastName = employeeDto.LastName;
            vm.Employee.Address = employeeDto.Address;
            vm.Employee.Phone = employeeDto.Phone;
            vm.Employee.StartDate = employeeDto.StartDate;
            vm.Employee.TerminationDate = employeeDto.TerminationDate;
            vm.Employee.Manager = employeeDto.Manager;

            return View(vm); // Views/Employees/Edit.cshtml
        }

        // POST: /employees/edit
        [Route("edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateEmployeeViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // Optional: run application-level validation (adjust validator to ignore the current id if required)
            //var validation = await _employeeValidator.ValidateNoDuplicateAsync(viewModel.Employee.FirstName, viewModel.Employee.LastName);
            //if (!validation.IsValid)
            //{
            //    ModelState.AddModelError(string.Empty, validation.ErrorMessage);
            //    return View(viewModel);
            //}

            var updateModel = new UpdateEmployeeModel
            {
                Id = viewModel.Employee.Id,
                FirstName = viewModel.Employee.FirstName,
                LastName = viewModel.Employee.LastName,
                Address = viewModel.Employee.Address,
                Phone = viewModel.Employee.Phone,
                StartDate = viewModel.Employee.StartDate,
                TerminationDate = viewModel.Employee.TerminationDate,
                Manager = viewModel.Employee.Manager
            };

            _updateCommand.Execute(updateModel);

            return RedirectToAction("index", "employees");
        }
    }
}