using Core.UserContext.Entities;
using Core.VaccineCardContext.Entities;
using Core.VaccineContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SharedContext.Data;

public class AppDbContext(DbContextOptions <AppDbContext> options ) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Vaccine> Vaccines { get; set; }
    public DbSet<VaccineCard> VaccineCards { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
    }
}