using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Application.RequestQuery.Employees
{
    public class EditEmployeeDto
    { 
                
        public string? Name { get; set; }  
        public string Gender { get; set; }
        public string? EmailAddress { get; set; }  
        public string? PhoneNumber { get; set; } 
         public string? CafeName { get; set; } 
        public Guid? CafeId { get; set; }
 
    }
}
