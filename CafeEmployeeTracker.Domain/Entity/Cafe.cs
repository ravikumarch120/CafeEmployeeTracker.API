using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Domain.Entity
{
    public class Cafe
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Logo { get; set; }

        [Required]
        public string Location { get; set; }

        public ICollection<EmployeeCafe> Employees { get; set; } = new List<EmployeeCafe>();

        //public Cafe(string name, string description, string logo, string location)
        //{
        //    Name = name;
        //    Description = description;
        //    Logo = logo;
        //    Location = location;
        //}


    }

}
