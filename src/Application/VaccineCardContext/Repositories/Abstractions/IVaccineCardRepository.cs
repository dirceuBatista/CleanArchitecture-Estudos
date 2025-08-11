using Core.VaccineCardContext.Entities;

namespace Application.VaccineCardContext.Repositories.Abstractions;

public interface IVaccineCardRepository
{
    Task<VaccineCard?> GetByIdCard(Guid id);
    Task<VaccineCard?> GetByIdAndVaccine(Guid id);
    void UpdateAsync(VaccineCard vaccineCard);
}