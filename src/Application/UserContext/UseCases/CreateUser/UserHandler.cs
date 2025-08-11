using Application.SharedContext.Repositories.Abstractions;
using Application.SharedContext.Results;
using Application.SharedContext.UseCases.Create;
using Application.UserContext.Repositories.Abstractions;
using Core.UserContext.Entities;
using Core.UserContext.ValueObjects;
using Core.VaccineCardContext.Entities;
using MediatR;

namespace Application.UserContext.UseCases.CreateUser;

public class UserHandler(IUserRepository repository, IUnitOfWork unitOfWork) : ICommandHandler<UserCommand, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(UserCommand request, CancellationToken cancellationToken)
    {
        var exists = await repository.CpfExistAsync(request.email);
        if (exists)
            return Result.Failure<UserResponse>(new Error("",""));
        
        var name = UserName.Create(request.name, request.name);
        var email = UserEmail.Create(request.email);
        var password = request.password;
        var cpf = UserCpf.Create(request.cpf);
        var age = UserAge.Create(request.age);
        var gender = UserGender.Create(request.gender);
        bool hasAllergy = !string.IsNullOrWhiteSpace(request.allergy?.Description);
        var allergy = UserAllergy.Create(hasAllergy, request.allergy?.Description ?? string.Empty);
        var sus = string.IsNullOrWhiteSpace(request.susNumber)
            ? null
            : UserSusNumber.Create(request.susNumber);
        

        var user = User.Create(name, email, password, age, allergy, gender, cpf, sus);
        
        
        await repository.SaveAsync(user);
        await unitOfWork.CommitAsync();

        var responser = new UserResponse
        (user.Name);
        
        return Result.Success(responser);
    }
}