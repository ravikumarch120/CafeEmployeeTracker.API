using CafeEmployeeTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Domain.Repositories
{
    public interface ICafeRepository
    {
        Task<List<(Cafe Cafe, int EmployeesCount)>> GetAllCafesAsync();
        Task<List<Cafe>> GetAllCafesByLocationAsync(string? location);
        Task CreateAsync(Cafe cafe);
        Task UpdateCafeDetailsAsync(Cafe cafe);
        Task DeleteAsync(Guid id);
        Task<Cafe?> GetCafeByIdAsync(Guid id);
        Task<Cafe?> GetCafeByNameAsync(string cafeName);

    }
}
