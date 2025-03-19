using CafeEmployeeTracker.Domain.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace CafeEmployeeTracker.Application.RequestQuery.Employees
{
    public class EmployeeDto
    {
        public string Id { get; set; } // Unique employee identifier in the format ‘UIXXXXXXX’ where the X is replaced with alpha numeric
        public string? Name { get; set; } // Name of the employee
        public string Gender { get;set; }
        public string? EmailAddress { get; set; } // Email address of the employee
        public string? PhoneNumber { get; set; } // Phone number of the employee
        public int? DaysWorked { get; set; } = 0; // Number of days the employee worked. It must be an integer and is derived from the current date minus the start date of the employee in the cafe
        public string? CafeName { get; set; } // Café’s name that the employee is under [leave blank if not assigned yet]
        public EmployeeDto()
        {
            
        }
        public EmployeeDto(string id, string name, string emailAddress, string phoneNumber, int daysWorked, string cafeName)
        {
            Id = id;
            Name = name;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            DaysWorked = daysWorked;
            CafeName = cafeName;
        }
    }
}