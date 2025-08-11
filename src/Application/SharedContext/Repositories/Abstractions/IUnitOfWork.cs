namespace Application.SharedContext.Repositories.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsync();
}