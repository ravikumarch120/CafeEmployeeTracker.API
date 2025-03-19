using CafeEmployeeTracker.Application.RequestQuery.Employees;
using CafeEmployeeTracker.Domain.Entity;
using CafeEmployeeTracker.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Application.Commands.Employees
{
    public record CreateEmployeeCommand(string Name, string Gender, string Email, string Phone, string CafeName) : IRequest<EmployeeDto>;

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly ICafeRepository _cafeRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public CreateEmployeeCommandHandler(ICafeRepository cafeRepository, IEmployeeRepository employeeRepository)
        {
            _cafeRepository = cafeRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var cafe = await _cafeRepository.GetCafeByNameAsync((request.CafeName));
            if (cafe == null)
            {
                throw new Exception("Cafe not found");
            }
            var employee = new Employee
            {
                Id = GenerateEmployeeId(),
                Name = request.Name,
                EmailAddress = request.Email,
                PhoneNumber = request.Phone,
                Gender = request.Gender
            };
            var employeeCafe = new EmployeeCafe
            {
                Employee = employee,
                Cafe = cafe,
                StartDate = DateTime.UtcNow
            };
            await _employeeRepository.CreateAsync(employee);
            await _employeeRepository.CreateEmployeeCafeAsync(employeeCafe);

            return new EmployeeDto
            {
                Id = !string.IsNullOrEmpty(employee.Id) ? employee.Id : string.Empty,
                Name = employee.Name ?? string.Empty,
                EmailAddress = employee.EmailAddress ?? string.Empty,
                PhoneNumber = employee.PhoneNumber ?? string.Empty,
                CafeName = cafe.Name ?? string.Empty
            };
        }

        private string GenerateEmployeeId()
        {
            var random = new Random();
            var id = "UI" + new string(Enumerable.Range(0, 7).Select(_ => (char)random.Next('A', 'Z' + 1)).ToArray());
            return id;
        }
    }

}
