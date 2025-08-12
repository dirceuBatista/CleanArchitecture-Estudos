using Application.UserContext.Repositories.Abstractions;
using Core.UserContext.Entities;
using Infrastructure.SharedContext.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UserContext.Repositories;

public class UserRepository( AppDbContext context) : IUserRepository
{
    public async Task<bool> EmailExistAsync(string email)
    {
        return await context.Users.AsNoTracking().AnyAsync(x => x.Email.Address == email);
    }
    public async Task SaveAsync(User user)
        =>await context.Users.AddAsync(user);
    
}