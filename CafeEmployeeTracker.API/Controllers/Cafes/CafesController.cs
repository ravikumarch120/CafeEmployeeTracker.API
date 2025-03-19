using CafeEmployeeTracker.Application.Commands.Cafe;
using CafeEmployeeTracker.Application.RequestQuery.Cafe;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeEmployeeTracker.API.Controllers.Cafes
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CafesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("by-location")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCafesByLocation([FromQuery] string? location)
        {
            var result = await _mediator.Send(new GetCafesByLocationQuery(location));
            return Ok(result);
        }
        [HttpPost("cafe")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCafe([FromBody] CafeDto request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new CreateCafeCommand(request.Name, request.Description, request.Location));
            return CreatedAtAction(nameof(Get), new { id = result }, result);
        }
       
        [HttpPut("cafe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCafe([FromBody] CafeDto request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(new UpdateCafeCommand(request.Name, request.Name, request.Description, request.Logo, request.Location));
            if (result.Equals(Unit.Value))
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("cafe/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCafe(Guid id)
        {
            var result = await _mediator.Send(new DeleteCafeCommand(id));
            if (result.Equals(Unit.Value))
            {
                return NoContent();
            }
            return NotFound();
        }


    }
}
