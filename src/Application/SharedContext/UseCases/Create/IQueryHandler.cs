using Application.SharedContext.Results;
using MediatR;

namespace Application.SharedContext.UseCases.Create;

public interface IQueryHandler<in TQuery> : IRequestHandler<TQuery, Result> where TQuery : IQuery
{
    
}

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
    where TResponse: IQueryResponse
{
    
}