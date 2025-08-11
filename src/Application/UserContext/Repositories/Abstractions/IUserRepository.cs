using Core.UserContext.Entities;
using Core.UserContext.ValueObjects;

namespace Application.UserContext.Repositories.Abstractions;

public interface IUserRepository
{
    Task<bool> CpfExistAsync(string email);
    Task SaveAsync(User user);

    
}