using Application.SharedContext.UseCases.Create;
using Core.VaccineCardContext.Entities;

namespace Application.VaccineCardContext.UseCases.Update;

public sealed record VaccineCardResponse(string Name, List<string> Vaccine) : ICommandResponse;