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
        
        var exists = await repository.VaccineExistAsync(request.Index);
        if(exists)
            return Result.Failure<VaccineResponse>(new Error("409", "Vacina ja cadastrada"));
        
        var name = VaccineName.Create(request.VaccineName);
        var manufacture = Manufacturer.Create(request.Manufacturer);
        var category = request.CategoryType;  
        var dose = request.DoseType;           
        var isMandatory = request.IsMandatory;
        var index = request.Index;
        var minAge = request.MinimumAgeInMonths;
        
        
        var vaccine = Vaccine.Create(name, manufacture, category, dose, minAge, isMandatory, index);
        
        try
        {
            await repository.SaveAsync(vaccine);
            await unitOfWork.CommitAsync();

            var responser = new VaccineResponse
                (vaccine.VacciName);

            return Result.Success(responser);
        }
        catch (Exception )
        {
            return Result.Failure<VaccineResponse>(new Error("500", "Erro interno no servidor."));
        }
    }
}