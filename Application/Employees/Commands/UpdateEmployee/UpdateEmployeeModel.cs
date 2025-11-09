using System;

namespace App.BespokedBikes.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeModel
    {
        public int Id { get; set; }                     // primary key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string Manager { get; set; }
    }
}