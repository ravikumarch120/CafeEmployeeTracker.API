using CafeEmployeeTracker.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Application.RequestQuery.Employees
{
    public record GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>;
    
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllEmployeeDetailsWithCafeAsync();
            return employees.Select(employee => new EmployeeDto
            {
                Id = !string.IsNullOrEmpty(employee.Employee.Id) ? employee.Employee.Id : string.Empty,
                EmailAddress = employee.Employee.EmailAddress ?? string.Empty,
                PhoneNumber = employee.Employee.PhoneNumber ?? string.Empty,
                DaysWorked = (DateTime.UtcNow - DateTime.Parse(employee.StartDate)).Days,
                Name = employee.Employee.Name ?? string.Empty,
                CafeName = employee.CafeName ?? string.Empty,
                CafeId = Guid.TryParse(employee.CafeId, out var cafeId) ? cafeId : (Guid?)null,
                Gender = employee.Employee.Gender,
                StartDate = DateTime.Parse(employee.StartDate).ToString("yyyy-MM-dd")
            });
        }
    }
}
