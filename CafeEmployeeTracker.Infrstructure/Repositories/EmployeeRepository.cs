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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CafeEmployeeTrackerDbContext _cafeEmployeeTrackerDbContext;

        public EmployeeRepository(CafeEmployeeTrackerDbContext cafeEmployeeTrackerDbContext)
        {
            _cafeEmployeeTrackerDbContext = cafeEmployeeTrackerDbContext;
        }

        public async Task CreateAsync(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            await _cafeEmployeeTrackerDbContext.Employees.AddAsync(employee);
            await _cafeEmployeeTrackerDbContext.SaveChangesAsync();
        }

        public async Task CreateEmployeeCafeAsync(EmployeeCafe employeeCafe)
        {
            if (employeeCafe == null)
            {
                throw new ArgumentNullException(nameof(employeeCafe));
            }

            await _cafeEmployeeTrackerDbContext.EmployeeCafes.AddAsync(employeeCafe);
            await _cafeEmployeeTrackerDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
           
            _cafeEmployeeTrackerDbContext.Employees.Remove(employee);
            await _cafeEmployeeTrackerDbContext.SaveChangesAsync();
        }

        public Task<List<Employee>> GetAllAsync(Guid? cafeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var employee = await _cafeEmployeeTrackerDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with Id {id} not found.");
            }

            return employee;
        }

 

        public async Task<IEnumerable<(Employee Employee, DateTime StartDate, string CafeName)>> GetEmployeesByCafeIdAsync(Guid cafeId)
        {
            var res = await _cafeEmployeeTrackerDbContext.EmployeeCafes
                .Where(x => x.CafeId == cafeId)
                .Select(x => new
                {
                    Employee = x.Employee,
                    StartDate = x.StartDate,
                    CafeName = x.Cafe.Name
                })
                .ToListAsync();

            return res.Select(x => (x.Employee, x.StartDate, x.CafeName));
        }

        public async Task UpdateEmployeeDetailsAsync(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            var existingEmployee = await _cafeEmployeeTrackerDbContext.Employees.FindAsync(employee.Id);
            if (existingEmployee == null)
            {
                throw new KeyNotFoundException($"Employee with Id {employee.Id} not found.");
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.EmailAddress = employee.EmailAddress;
            existingEmployee.PhoneNumber = employee.PhoneNumber;
            existingEmployee.Gender = employee.Gender;

            _cafeEmployeeTrackerDbContext.Employees.Update(existingEmployee);
            await _cafeEmployeeTrackerDbContext.SaveChangesAsync();
        }
    }
}
