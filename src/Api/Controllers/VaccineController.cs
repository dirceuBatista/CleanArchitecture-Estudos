using Application.VaccineContext.UseCases.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
public class VaccineController(IMediator mediator) : ControllerBase
{
    [HttpPost("v1/vaccines")]
    public async Task<ActionResult<VaccineResponse>> Create(
        [FromBody] VaccineCommand command, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(command, cancellationToken);
        if (!response.IsSuccess)
            return BadRequest(response.Error);
        return Ok(response);
    }
    
}