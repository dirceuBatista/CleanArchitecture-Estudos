using Application.SharedContext.Repositories.Abstractions;

namespace Infrastructure.SharedContext.Data;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }
}