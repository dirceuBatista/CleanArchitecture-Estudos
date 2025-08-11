using Core.VaccineCardContext.Entities;
using Core.VaccineContext.Entities;

namespace Application.VaccineContext.Repositories.Abstractions;

public interface IVaccineRepository
{
    Task<bool> VaccineExistAsync(string index);
    Task<Vaccine?> VaccineExistAsyncById(Guid id);
    Task SaveAsync(Vaccine vaccine);
}