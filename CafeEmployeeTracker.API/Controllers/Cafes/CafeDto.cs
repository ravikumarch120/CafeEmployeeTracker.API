using System.ComponentModel.DataAnnotations;

namespace CafeEmployeeTracker.API.Controllers.Cafes
{
    public class CafeDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Logo { get; set; }
        [Required]
        public string Location { get; set; }

    }
}
