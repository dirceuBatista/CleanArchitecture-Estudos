using Application.VaccineContext.Repositories.Abstractions;
using Core.VaccineCardContext.Entities;
using Core.VaccineContext.Entities;
using Infrastructure.SharedContext.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.VaccineContext.repositories;

public class VaccineRepository( AppDbContext context) : IVaccineRepository
{
    public async Task<bool> VaccineExistAsync(string index)
    {
        return await context.Vaccines.AsNoTracking().AnyAsync(x => x.Index == index);
    }
    public async Task<Vaccine?> VaccineExistAsyncById(Guid id)
    {
        return await context.Vaccines.FirstOrDefaultAsync(c => c.Id == id);

    }
    public async Task SaveAsync(Vaccine vaccine)
        =>await context.Vaccines.AddAsync(vaccine);
    
}