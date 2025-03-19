using CafeEmployeeTracker.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Application.Commands.Employees
{
    public record UpdateEmployeeCommand(string Id, string Name, string Email, string PhoneNumber) : IRequest<Unit>;

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(request.Id);
                if (employee == null)
                {
                    throw new Exception("Employee not found");
                }
                employee.Name = request.Name;
                employee.EmailAddress = request.Email;
                employee.PhoneNumber = request.PhoneNumber;
                await _employeeRepository.UpdateEmployeeDetailsAsync(employee);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception($"Error updating employee: {ex.Message}", ex);
            }
        }
    }
}
