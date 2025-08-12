using Core.UserContext.Entities;
using Core.UserContext.ValueObjects;

namespace Application.UserContext.Repositories.Abstractions;

public interface IUserRepository
{
    Task<bool> EmailExistAsync(string email);
    Task SaveAsync(User user);

    
}