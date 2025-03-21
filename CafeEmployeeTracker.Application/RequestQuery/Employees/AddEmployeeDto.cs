using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Application.RequestQuery.Employees
{
    public class AddEmployeeDto
    {
         public string? Name { get; set; } // Name of the employee
        public string Gender { get; set; }
        public string? EmailAddress { get; set; } // Email address of the employee
        public string? PhoneNumber { get; set; } // Phone number of the employee
        public string? cafeId { get; set; } // Café’s name that the employee is under [leave blank if not assigned yet]
     }
}
