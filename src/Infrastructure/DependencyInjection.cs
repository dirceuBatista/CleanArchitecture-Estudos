using Application.SharedContext.Repositories.Abstractions;
using Application.UserContext.Repositories.Abstractions;
using Application.VaccineCardContext.Repositories.Abstractions;
using Application.VaccineContext.Repositories.Abstractions;
using Infrastructure.SharedContext.Data;
using Infrastructure.UserContext.Repositories;
using Infrastructure.vaccineCardContext.Repositories;
using Infrastructure.VaccineContext.repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddTransient<IUserRepository, UserRepository>();
        serviceCollection.AddTransient<IVaccineRepository, VaccineRepository>();
        serviceCollection.AddTransient<IVaccineCardRepository, VaccineCardRepository>();
        return serviceCollection;
    }
}