using Application.SharedContext.Repositories.Abstractions;
using Application.SharedContext.Results;
using Application.SharedContext.UseCases.Create;
using Application.UserContext.Repositories.Abstractions;
using Core.UserContext.Entities;
using Core.UserContext.ValueObjects;


namespace Application.UserContext.UseCases.CreateUser;

public class UserHandler(IUserRepository repository, IUnitOfWork unitOfWork) : ICommandHandler<UserCommand, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(UserCommand request, CancellationToken cancellationToken)
    {
        var exists = await repository.EmailExistAsync(request.Email);
        if (exists)
            return Result.Failure<UserResponse>(new Error("409","O Email jA esta cadastrado"));
        
        var name = UserName.Create(request.FirstName,request.LastName);
        var email = UserEmail.Create(request.Email);
        var password = request.Password;
        var cpf = UserCpf.Create(request.Cpf);
        var age = UserAge.Create(request.Age);                                  
        var gender = UserGender.Create(request.Gender);
        var allergy = UserAllergy.Create(request.Allergy);
        var sus = UserSusNumber.Create(request.SusNumber);
        

        var user = User.Create(name, email, password, age, allergy, gender, cpf, sus);
        
        try
        {

            await repository.SaveAsync(user);
            await unitOfWork.CommitAsync();

            var responser = new UserResponse
                (user.Name);

            return Result.Success(responser);
        }
        catch (Exception)
        {
            return Result.Failure<UserResponse>(new Error("500", "Erro interno no servidor."));
        }
    }
}