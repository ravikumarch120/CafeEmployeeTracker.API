using CafeEmployeeTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<(Employee Employee, string CafeId, string StartDate, string CafeName )>> GetAllEmployeeDetailsWithCafeAsync();
        Task<Employee> GetByIdAsync(string id);
        Task<List<Employee>> GetAllAsync(Guid? cafeId);
        Task CreateAsync(Employee employee);
        Task CreateEmployeeCafeAsync(EmployeeCafe employeeCafe);

        Task UpdateEmployeeDetailsAsync(Employee employee);
        Task DeleteEmployeeAsync(Employee employee);

        Task<(Employee Employee, string CafeId, string StartDate, string CafeName)?> GetEmployeeCafeDetailsAsync(string EmpId);
        Task<IEnumerable<(Employee Employee, DateTime StartDate, string CafeName )>> GetEmployeesByCafeIdAsync(Guid cafeId);
    }
}
