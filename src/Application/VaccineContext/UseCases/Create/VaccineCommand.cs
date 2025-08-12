using Application.SharedContext.UseCases.Create;
using Core.VaccineContext.Enums;
using Core.VaccineContext.ValueObjects;
using MediatR;

namespace Application.VaccineContext.UseCases.Create;

public sealed record VaccineCommand(
    string VaccineName, string Manufacturer, VaccineCategory CategoryType, VaccineDose DoseType, int? MinimumAgeInMonths, bool IsMandatory, string Index) 
    : ICommand<VaccineResponse>;

    
