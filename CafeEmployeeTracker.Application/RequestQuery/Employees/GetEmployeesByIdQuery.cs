using CafeEmployeeTracker.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Application.RequestQuery.Employees
{
    public record GetEmployeesByIdQuery(string EmpId) : IRequest<EmployeeDto>;
    
public class GetEmployeesByIdQueryHandler : IRequestHandler<GetEmployeesByIdQuery, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetEmployeesByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeDto> Handle(GetEmployeesByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeCafeDetailsAsync(request.EmpId);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            DateTime? startDate = null;
            if (DateTime.TryParse(employee.Value.StartDate, out var parsedDate))
            {
                startDate = parsedDate;
            }
            return new EmployeeDto
            {
                Id = employee.Value.Employee.Id,
                Name = employee.Value.Employee.Name ?? string.Empty,
                EmailAddress = employee.Value.Employee.EmailAddress ?? string.Empty,
                PhoneNumber = employee.Value.Employee.PhoneNumber ?? string.Empty,
                Gender = employee.Value.Employee.Gender ?? string.Empty,
                CafeId = Guid.TryParse(employee.Value.CafeId, out var cafeId) ? cafeId : (Guid?)null,
                CafeName = employee.Value.CafeName ?? string.Empty,
                StartDate = startDate?.ToString("yyyy-MM-dd") ?? string.Empty,
                DaysWorked = startDate is null ? 0 : (DateTime.UtcNow - startDate.Value).Days,
            };
        }
    }
}
