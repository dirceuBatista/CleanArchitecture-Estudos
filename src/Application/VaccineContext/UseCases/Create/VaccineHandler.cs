using Application.SharedContext.Repositories.Abstractions;
using Application.SharedContext.Results;
using Application.SharedContext.UseCases.Create;
using Application.VaccineContext.Repositories.Abstractions;
using Core.VaccineContext.Entities;
using Core.VaccineContext.ValueObjects;


namespace Application.VaccineContext.UseCases.Create;

public class VaccineHandler(IVaccineRepository repository, IUnitOfWork unitOfWork) : ICommandHandler<VaccineCommand, VaccineResponse>
{
    public async Task<Result<VaccineResponse>> Handle(VaccineCommand request, CancellationToken cancellationToken)
    {
        
        var exists = await repository.VaccineExistAsync(request.index);
        if(exists)
            return Result.Failure<VaccineResponse>(new Error("404", " dale"));
        
        var name = VaccineName.Create(request.vaccineName);
        var manufacture = Manufacturer.Create(request.manufacturer);
        var category = request.categoryType;  
        var dose = request.doseType;           
        var isMandatory = request.isMandatory;
        var index = request.index;
        var minAge = request.minimumAgeInMonths;
        
        
        
        var vaccine = Vaccine.Create(name, manufacture, category, dose, minAge, isMandatory, index);
        
        await repository.SaveAsync(vaccine);
        await unitOfWork.CommitAsync();

        var responser = new VaccineResponse
            (vaccine.vacciName);
        
        return Result.Success(responser);
    }
}