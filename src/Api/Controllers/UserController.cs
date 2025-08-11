using Application.UserContext.UseCases.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpPost("v1/users")]
    public async Task<ActionResult<UserResponse>> Create([FromBody] UserCommand request,
        CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}