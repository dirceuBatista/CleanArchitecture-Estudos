using Application.SharedContext.UseCases.Create;
using Core.UserContext.ValueObjects;
using Core.VaccineCardContext.Entities;

namespace Application.UserContext.UseCases.CreateUser;

public record UserCommand(UserName name, UserEmail email, string password, int age, UserAllergy allergy, char gender ,UserCpf cpf, UserSusNumber susNumber): ICommand<UserResponse>
{
    
}