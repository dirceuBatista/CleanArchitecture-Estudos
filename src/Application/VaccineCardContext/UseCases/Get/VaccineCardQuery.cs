using Application.SharedContext.UseCases.Create;

namespace Application.VaccineCardContext.UseCases.Get;

public record VaccineCardQuery(Guid Id) : IQuery<VaccineCardQueryResponse>;

    
