using Application.SharedContext.Results;
using MediatR;

namespace Application.SharedContext.UseCases.Create;

public interface ICommand : IRequest<Result>
{
    
}
public interface ICommand<TCommandResponse> : IRequest<Result<TCommandResponse>> where TCommandResponse : ICommandResponse
{
    
}