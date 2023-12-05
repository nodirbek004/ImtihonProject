using HospitalInformationSystem.Domain.Commons;

namespace Poliklinika.Infrastructure.IRepasitories;

public interface IRepository<T>where T : Auditable
{
    Task<T> CreateAsync(T entity);
    T Update(T entity);
    Task<T> GetByIdAsync(int id);
    void Delete(T entity);
    IQueryable<T> GetAllAsync();
    Task<int> SaveAsync();
}
