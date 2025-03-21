using CafeEmployeeTracker.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Application.RequestQuery.Employees
{
    public record GetEmployeesByCafeIdQuery(Guid cafeId) : IRequest<IEnumerable<EmployeeDto>>;
    public class GetEmployeesByCafeIdQueryHandler : IRequestHandler<GetEmployeesByCafeIdQuery, IEnumerable<EmployeeDto>>
    {
        private readonly ICafeRepository _cafeRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public GetEmployeesByCafeIdQueryHandler(ICafeRepository cafeRepository, IEmployeeRepository employeeRepository)
        {
            _cafeRepository = cafeRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesByCafeIdQuery request, CancellationToken cancellationToken)
        {
            var cafe = await _cafeRepository.GetCafeByIdAsync(request.cafeId);
            if (cafe == null)
            {
                throw new Exception("Cafe not found");
            }
            var employees = await _employeeRepository.GetEmployeesByCafeIdAsync(request.cafeId);
            return employees.Select(employee => new EmployeeDto
            {
                Id = !string.IsNullOrEmpty(employee.Employee.Id) ? employee.Employee.Id : string.Empty,
                EmailAddress = employee.Employee.EmailAddress ?? string.Empty,
                PhoneNumber = employee.Employee.PhoneNumber ?? string.Empty,
                DaysWorked = (DateTime.UtcNow - employee.StartDate).Days,
                Name = employee.Employee.Name ?? string.Empty,
                CafeName = employee.CafeName ?? string.Empty,
                CafeId = request.cafeId,
                 StartDate = employee.StartDate.ToString("yyyy-MM-dd")
            });
        }
    }

}
