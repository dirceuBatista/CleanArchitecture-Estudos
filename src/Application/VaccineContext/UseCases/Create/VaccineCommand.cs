using Application.SharedContext.UseCases.Create;
using Core.VaccineContext.Enums;
using Core.VaccineContext.ValueObjects;
using MediatR;

namespace Application.VaccineContext.UseCases.Create;

public sealed record VaccineCommand(
    VaccineName vaccineName,
    Manufacturer manufacturer,
    VaccineCategory categoryType,
    VaccineDose doseType,
    int? minimumAgeInMonths,
    bool isMandatory, string index) : ICommand<VaccineResponse>;

    
