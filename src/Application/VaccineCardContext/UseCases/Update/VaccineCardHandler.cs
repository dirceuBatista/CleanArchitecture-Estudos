using Application.SharedContext.Repositories.Abstractions;
using Application.SharedContext.Results;
using Application.SharedContext.UseCases.Create;
using Application.VaccineCardContext.Repositories.Abstractions;
using Application.VaccineContext.Repositories.Abstractions;


namespace Application.VaccineCardContext.UseCases.Update;

public class VaccineCardHandler (IVaccineCardRepository repository,IVaccineRepository vaccineRepository, IUnitOfWork unitOfWork): ICommandHandler<VaccineCardCommand, VaccineCardResponse>
{
    public async Task<Result<VaccineCardResponse>> Handle(VaccineCardCommand request, CancellationToken cancellationToken)
    {
        var vaccineCard = await repository.GetByIdCard(request.CardId);
        if(vaccineCard == null)
           return Result.Failure<VaccineCardResponse>(new Error("404", "Cartão de vacina não encontrado."));
        
        var vaccine = await vaccineRepository.VaccineExistAsyncById(request.VaccineId);
        if(vaccine == null)
            return Result.Failure<VaccineCardResponse>(new Error("404", "Vacina não encontrado."));
        
        try
        {
            var vaccineName = vaccine.VacciName;
            vaccineCard.AddVaccineName(vaccineName);

            repository.UpdateAsync(vaccineCard);
            await unitOfWork.CommitAsync();

            var responser = new VaccineCardResponse
                (vaccineCard.UserName, vaccineCard.VaccineName);

            return Result.Success(responser);
        }
        catch (Exception )
        {
            return Result.Failure<VaccineCardResponse>(new Error("500", "Erro interno no servidor."));
        }
    }
}