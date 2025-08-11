using Application.SharedContext.UseCases.Create;
using Core.VaccineContext.ValueObjects;

namespace Application.VaccineContext.UseCases.Create;

public sealed record VaccineResponse(VaccineName Name) : ICommandResponse;