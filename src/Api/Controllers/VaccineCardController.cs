using Application.SharedContext.Results;
using Application.VaccineCardContext.UseCases.Get;
using Application.VaccineCardContext.UseCases.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;
[ApiController]
public class VaccineCardController(IMediator mediator) : ControllerBase
{
    [HttpPut("v1/vaccineCards")]
    public async Task<ActionResult<VaccineCardResponse>> Update(
        [FromBody] VaccineCardCommand command, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(command, cancellationToken);
        if (!response.IsSuccess)
            return BadRequest(response.Error);
        return Ok(response);
    }
    
    [HttpGet("v1/vaccineCards/{id}")]
    public async Task<ActionResult<Result<VaccineCardQueryResponse>>> Create(Guid id,CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new VaccineCardQuery(id), cancellationToken);
        return Ok(response);
    }

}