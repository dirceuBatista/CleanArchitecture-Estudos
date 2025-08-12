using Application.SharedContext.UseCases.Create;
using Core.UserContext.ValueObjects;

namespace Application.UserContext.UseCases.CreateUser;

public record UserResponse(UserName Name) : ICommandResponse;