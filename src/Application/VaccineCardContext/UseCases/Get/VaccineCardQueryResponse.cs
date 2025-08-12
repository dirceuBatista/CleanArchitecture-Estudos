using Application.SharedContext.UseCases.Create;

namespace Application.VaccineCardContext.UseCases.Get;

public sealed record VaccineCardQueryResponse(string CardName,List<string> VaccineName) : IQueryResponse;