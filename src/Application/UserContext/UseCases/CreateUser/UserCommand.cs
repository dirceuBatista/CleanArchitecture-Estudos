using Application.SharedContext.UseCases.Create;


namespace Application.UserContext.UseCases.CreateUser;

public record UserCommand(string FirstName, string LastName, string Email, string Password, int Age, string? Allergy , char Gender ,string Cpf, string SusNumber): ICommand<UserResponse>
{
    
}