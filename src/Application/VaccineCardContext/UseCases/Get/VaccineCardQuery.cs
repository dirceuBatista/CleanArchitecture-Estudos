using Application.SharedContext.UseCases.Create;

namespace Application.VaccineCardContext.UseCases.Get;

public sealed record VaccineCardQuery(Guid Id) : IQuery<VaccineCardQueryResponse>;

    
