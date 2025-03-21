using CafeEmployeeTracker.Domain.Entity;
using CafeEmployeeTracker.Domain.Repositories;
using CafeEmployeeTracker.Infrstructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Infrstructure.Repositories
{
    public class CafeRepository : ICafeRepository
    {
        private readonly CafeEmployeeTrackerDbContext _cafeEmployeeTrackerDbContext;

        public CafeRepository(CafeEmployeeTrackerDbContext cafeEmployeeTrackerDbContext )
        {
            _cafeEmployeeTrackerDbContext = cafeEmployeeTrackerDbContext;
        }
        public async Task CreateAsync(Cafe cafe)
        {
            await _cafeEmployeeTrackerDbContext.Cafes.AddAsync(cafe);
            await _cafeEmployeeTrackerDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var cafe = await _cafeEmployeeTrackerDbContext.Cafes.FindAsync(id);
            if (cafe != null)
            {
                _cafeEmployeeTrackerDbContext.Cafes.Remove(cafe);
                await _cafeEmployeeTrackerDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<(Cafe Cafe, int EmployeesCount)>> GetAllCafesAsync()
        {
            var cafes = await _cafeEmployeeTrackerDbContext.Cafes
                .Include(c => c.Employees)
                .ToListAsync();

            var result = cafes.Select(c => (Cafe: c, EmployeesCount: c.Employees.Count)).ToList();

            return result;
        }

        public Task<List<Cafe>> GetAllCafesByLocationAsync(string? location)
        {
            List<Cafe> res;
            if (string.IsNullOrEmpty(location))
            {
                res = _cafeEmployeeTrackerDbContext.Cafes.ToList();
            }
            else
            {
                res = _cafeEmployeeTrackerDbContext.Cafes.Where(x => x.Location == location).ToList();
            }
            return Task.FromResult(res ?? new List<Cafe>());
        }

        public async Task<Cafe?> GetCafeByIdAsync(Guid id)
        {
            return await _cafeEmployeeTrackerDbContext.Cafes.FindAsync(id);
        }

        public async Task<Cafe?> GetCafeByNameAsync(string cafeName)
        {
            return await _cafeEmployeeTrackerDbContext.Cafes
                .FirstOrDefaultAsync(c => c.Name == cafeName);
        }

        public async Task UpdateCafeDetailsAsync(Cafe cafe)
        {
            var existingCafe = await _cafeEmployeeTrackerDbContext.Cafes.FindAsync(cafe.Id);
            if (existingCafe != null)
            {
                existingCafe.Name = cafe.Name;
                existingCafe.Description = cafe.Description;
                existingCafe.Logo = cafe.Logo;
                existingCafe.Location = cafe.Location;
                _cafeEmployeeTrackerDbContext.Cafes.Update(existingCafe);
                await _cafeEmployeeTrackerDbContext.SaveChangesAsync();
            }
        }
    }
}
