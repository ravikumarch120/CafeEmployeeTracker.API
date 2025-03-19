using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Domain.Entity
{
    public class Employee
    {
        [Key]
        [Required]
        public string Id { get; set; } // Format 'UIXXXXXXX'

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [RegularExpression("^[89][0-9]{7}$", ErrorMessage = "Phone number must start with 8 or 9 and be 8 digits long")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Gender { get; set; } // Male/Female

        public EmployeeCafe EmployeeCafe { get; set; }
    }

}
