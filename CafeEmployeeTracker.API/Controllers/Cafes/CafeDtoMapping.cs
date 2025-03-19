using CafeEmployeeTracker.Domain.Entity;

namespace CafeEmployeeTracker.API.Controllers.Cafes
{
    public static class CafeDtoMapping
    {
          public static CafeDto MapToCafeDto(this Cafe cafe)
        {
            return new CafeDto
            {
                Name = cafe.Name,
                Description = cafe.Description,
                Logo = cafe.Logo,
                Location = cafe.Location
            };
        }

    }
}
