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
            return Result.Failure<VaccineCardQueryResponse>(new Error("404", "Cartão de vacina nao encontrado"));

        try
        {
            var response = new VaccineCardQueryResponse(card.UserName, card.VaccineName);
            return Result.Success(response);
        }
        catch (Exception )
        {
            return Result.Failure<VaccineCardQueryResponse>(new Error("500", "Erro interno no servidor."));
        }
    
    }
}