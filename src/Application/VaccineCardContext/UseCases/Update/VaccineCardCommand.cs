using Application.SharedContext.UseCases.Create;
using Core.VaccineContext.Enums;
using Core.VaccineContext.ValueObjects;

namespace Application.VaccineCardContext.UseCases.Update;

public sealed record VaccineCardCommand(Guid CardId, Guid VaccineId): ICommand<VaccineCardResponse>;