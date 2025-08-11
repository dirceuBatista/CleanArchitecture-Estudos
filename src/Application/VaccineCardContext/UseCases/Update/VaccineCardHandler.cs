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
           return Result.Failure<VaccineCardResponse>(new Error("404", " dale"));
        
        var vaccine = await vaccineRepository.VaccineExistAsyncById(request.VaccineId);
        if(vaccine == null)
            return Result.Failure<VaccineCardResponse>(new Error("404", " dale"));
        
        
        var vaccineName = vaccine.vacciName;  
        vaccineCard.AddVaccineName(vaccineName);
        
        repository.UpdateAsync(vaccineCard);
        await unitOfWork.CommitAsync();
        
        var responser = new VaccineCardResponse
            (vaccineCard.UserName, vaccineCard.VaccineName);
        
        return Result.Success(responser);
    }
}