using Core.UserContext.Errors;
using FluentValidation;

namespace Application.UserContext.UseCases.CreateUser;

public class Validator : AbstractValidator<UserCommand>
{
    public Validator()
    {
        RuleFor(x => x.FirstName)
            .NotNull()
            .MinimumLength(3).WithMessage(ErrorMessage.Name.InvalidLength);
        RuleFor(x => x.LastName)
            .NotNull()
            .MinimumLength(3).WithMessage(ErrorMessage.Name.InvalidLength);

        
        RuleFor(x => x.Cpf)
            .NotEmpty().WithMessage(ErrorMessage.Cpf.InvalidNullOrEmpty)
            .NotNull().WithMessage(ErrorMessage.Cpf.InvalidNullOrEmpty)
            .Length(11).WithMessage(ErrorMessage.Cpf.InvalidLength)
            .Matches(@"^\d{11}$").WithMessage(ErrorMessage.Cpf.Invalid);;

        RuleFor(x => x.Age)
            .NotNull().WithMessage(ErrorMessage.Age.InvalidNullOrEmpty)
            .InclusiveBetween(0, 100).WithMessage(ErrorMessage.Age.InvalidLength);;

        RuleFor(x => x.Gender)
            .NotNull().WithMessage(ErrorMessage.Gender.InvalidNullOrEmpty)
            .NotEmpty().WithMessage(ErrorMessage.Gender.InvalidNullOrEmpty)
            .Must(g => new[] { "M", "F" }.Contains(g.ToString()))
            .WithMessage("Gênero deve ser M ou F");;
        
        RuleFor(x => x.Email)
            .NotNull().WithMessage(ErrorMessage.Email.InvalidNullOrEmpty)
            .NotEmpty().WithMessage(ErrorMessage.Email.InvalidNullOrEmpty)
            .EmailAddress().WithMessage(ErrorMessage.Email.Invalid);
    }
}