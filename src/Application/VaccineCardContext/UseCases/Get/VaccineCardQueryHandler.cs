using Application.SharedContext.Results;
using Application.SharedContext.UseCases.Create;
using Application.VaccineCardContext.Repositories.Abstractions;

namespace Application.VaccineCardContext.UseCases.Get;

public class VaccineCardQueryHandler(IVaccineCardRepository repository) : IQueryHandler<VaccineCardQuery, VaccineCardQueryResponse>
{
    public async Task<Result<VaccineCardQueryResponse>> Handle(VaccineCardQuery request, CancellationToken cancellationToken)
    {
        var card = await repository.GetByIdAndVaccine(request.Id);
        if (card is null)
            return Result.Failure<VaccineCardQueryResponse>(new Error("404", "nao encontrado"));

        var response = new VaccineCardQueryResponse(card.UserName ,card.VaccineName);
        return Result.Success(response);
    
    }
}