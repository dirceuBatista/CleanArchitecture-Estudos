using Application.SharedContext.Results;
using MediatR;

namespace Application.SharedContext.UseCases.Create;

public interface IQuery :IRequest<Result>
{
    
}

public interface IQuery<TQueryResponse> : IRequest<Result<TQueryResponse>> where TQueryResponse : IQueryResponse
{
    
}