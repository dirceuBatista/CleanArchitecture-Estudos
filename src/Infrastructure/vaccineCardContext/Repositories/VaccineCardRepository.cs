using Application.VaccineCardContext.Repositories.Abstractions;
using Core.VaccineCardContext.Entities;
using Infrastructure.SharedContext.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.vaccineCardContext.Repositories;

public class VaccineCardRepository(AppDbContext context) : IVaccineCardRepository 
{
    public async Task<VaccineCard?> GetById(Guid id)
    {
        return await context.VaccineCards.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<VaccineCard?> GetByIdCard(Guid id)
    {
        return await context.VaccineCards.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<VaccineCard?> GetByIdAndVaccine(Guid id)
    {
        return await context.VaccineCards.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public void UpdateAsync(VaccineCard vaccineCard)
    {
        context.VaccineCards.Update(vaccineCard);
        
    }
}