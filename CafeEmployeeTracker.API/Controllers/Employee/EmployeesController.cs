using CafeEmployeeTracker.Application.Commands.Employees;
using CafeEmployeeTracker.Application.RequestQuery.Employees;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeEmployeeTracker.API.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]

        public async Task<IActionResult> GetEmployees([FromQuery] Guid cafeId)
        {
            var query = new GetEmployeesByCafeIdQuery(cafeId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]

        public async Task<IActionResult> GetEmployeeById(string id)
        {
            var query = new GetEmployeesByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEmployee([FromBody] AddEmployeeDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.EmailAddress) || string.IsNullOrEmpty(request.PhoneNumber) || string.IsNullOrEmpty(request.cafeId))
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new CreateEmployeeCommand(request.Name, request.Gender, request.EmailAddress, request.PhoneNumber, request.cafeId));
            return Ok(result);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateEmployee(string id ,[FromBody] EditEmployeeDto request)
        {
            if (request == null || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.EmailAddress) || string.IsNullOrEmpty(request.PhoneNumber) || string.IsNullOrEmpty(request.CafeName))
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateEmployeeCommand(id, request.Name, request.EmailAddress, request.PhoneNumber));
                   return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            if (string.IsNullOrEmpty(id) || id is null)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new DeleteEmployeeCommand(id));
            if (!result.Equals(Unit.Value))
            {
                return NotFound();
            }

            return Ok(result);
        }
     
        
        
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> GetAllEmployees()
        {
            var query = new GetAllEmployeesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }


    }
}
