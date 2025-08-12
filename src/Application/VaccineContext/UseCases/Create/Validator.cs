
using Core.VaccineContext.Errors;
using FluentValidation;

namespace Application.VaccineContext.UseCases.Create;

public class Validator : AbstractValidator<VaccineCommand>
{
    public Validator()
    {
        RuleFor(x => x.VaccineName)
            .NotNull().WithMessage(ErrorMessageVaccine.VaccineName.InvalidNullOrEmpty);

        RuleFor(v => v.Manufacturer)
            .NotNull().WithMessage(ErrorMessageVaccine.Manufacturer.InvalidNullOrEmpty)
            .NotEmpty().WithMessage(ErrorMessageVaccine.Manufacturer.InvalidNullOrEmpty)
            .MinimumLength(5).WithMessage(ErrorMessageVaccine.Manufacturer.Invalid);

        RuleFor(v => v.CategoryType)
            .NotNull().WithMessage(ErrorMessageVaccine.VaccineCategory.InvalidNullOrEmpty)
            .IsInEnum().WithMessage(ErrorMessageVaccine.VaccineCategory.Invalid);

        RuleFor(v => v.DoseType)
            .NotNull().WithMessage(ErrorMessageVaccine.VaccineDose.InvalidNullOrEmpty)
            .IsInEnum().WithMessage(ErrorMessageVaccine.VaccineDose.Invalid);

        RuleFor(v => v.Index)
            .NotNull().WithMessage("Índice é obrigatório.")
            .NotEmpty().WithMessage("Índice não pode ser vazio.");
    }
}