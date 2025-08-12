using FluentValidation;

namespace Application.VaccineCardContext.UseCases.Update;

public class Validator : AbstractValidator<VaccineCardCommand>
{
    public Validator()
    {
        RuleFor(x => x.VaccineId)
            .NotEmpty().WithMessage("O Id Da vacina não pode estar vazino")
            .NotNull().WithMessage("O Id da vacina não pode ser nulo");
        RuleFor(x => x.CardId)
            .NotEmpty().WithMessage("O Id do Cartão de vacina não pode estar vazino")
            .NotNull().WithMessage("O Id do Cartão de vacina não pode ser nulo");
    }
}