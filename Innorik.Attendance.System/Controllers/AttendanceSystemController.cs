using Innorik.Attendance.System.Application.Command.Commands.Request;
using Innorik.Attendance.System.Application.Command.Query.Handlers;
using Innorik.Attendance.System.Application.Command.Query.Request;
using Innorik.Attendance.System.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Innorik.Attendance.System.Application.Dtos.CommandDto;

namespace Innorik.Attendance.System.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttendanceSystemController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AttendanceSystemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> SearchLoggingSystem([FromQuery] string? search = null)
        {          
              
            var response = await _mediator.Send(new SearchAttendanceRequest
            {
                Search = search ?? string.Empty
            });
            if (response == null)
                return BadRequest(StatusCode(404, "No records found"));
            return Ok(response);
                                
                              
        }

        [HttpGet]
        [Route("ValidateDate")]
        public async Task<IActionResult> CheckDate()
        {
                     
            var response = await _mediator.Send(new isLateResponse
            {
                Date = DateTime.UtcNow,

            });
            return Ok(response);                   
          
        }

        [HttpPost]
        [Route("CreateCheckIn")]
        public async Task<ActionResult> CheckIn([FromBody] CreateCheckInDto create)
        {
            try
            {
                if (true)
                {
                    var response = await _mediator.Send(new CreateCheckInRequest
                    {
                        Create = create
                    });
                    while (response != null)
                    {
                        return Ok(response);
                    }

                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return BadRequest(StatusCode(404, "Failed"));
        }
    }
}

