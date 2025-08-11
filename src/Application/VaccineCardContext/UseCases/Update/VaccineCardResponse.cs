using Application.SharedContext.UseCases.Create;
using Core.VaccineCardContext.Entities;

namespace Application.VaccineCardContext.UseCases.Update;

public record VaccineCardResponse(string name, List<string> vaccine) : ICommandResponse;