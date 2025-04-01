using MediatR;
using Microsoft.AspNetCore.Mvc;
using Event.Application.Commands;
using Event.Application.Queries;
namespace Event.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _mediator.Send(new GetAllEventQuery());
            if (response.succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAsync([FromQuery] int EventId)
        {
            var response = await _mediator.Send(new GetByIdEventQuery() { Id = EventId });
            if (response.succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
        //feature pagination is not implemented yet
        // [HttpGet("GetAllWithPagination")]
        // public async Task<IActionResult> GetAllWithPaginationAsync([FromQuery] GetAllWithPaginationEventQuery query)
        // {
        //     var response = await _mediator.Send(query);
        //     if (response.succcess)
        //     {
        //         return Ok(response);
        //     }

        //     return BadRequest(response);
        // }

        [HttpPost("Insert")]
        public async Task<ActionResult> InsertAsync([FromBody] CreateEventCommand command)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command);

            if (response.succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateEventCommand command)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command);

            if (response.succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("Delete")]
        public async Task<ActionResult> DeleteAsync([FromQuery] DeleteEventCommand command)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command);

            if (response.succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

    }
}