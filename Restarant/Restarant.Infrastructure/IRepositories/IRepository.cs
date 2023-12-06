using Restarant.Domain.Commons;

namespace Restarant.Infrastructure.IRepositories;

public interface IRepository<T> where T : AudiTable
{
    Task<T> CreateAsync(T entity);
    T Update(T entity);
    Task<T> GetByIdAsync(long id);
    void Delete(T entity);
    IQueryable<T> GetAllAsync();
    Task<int> SaveAsync();
}
