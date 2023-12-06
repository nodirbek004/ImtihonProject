using Microsoft.EntityFrameworkCore;
using Restarant.Domain.Commons;
using Restarant.Infrastructure.DbContexts;
using Restarant.Infrastructure.IRepositories;

namespace Restarant.Infrastructure.Repositoies;

public class Repositories<T>:IRepository<T> where T : AudiTable
{
    public readonly AppDbContext _appDbContext;
    private readonly DbSet<T> _dbSet;
    public Repositories(AppDbContext appDbContext)
    {
        this._appDbContext = appDbContext;
        _dbSet = appDbContext.Set<T>();
    }
    public async Task<T> CreateAsync(T entity)
    {
        var res = await _dbSet.AddAsync(entity);

        return entity;
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public IQueryable<T> GetAllAsync()
        => _dbSet.AsQueryable();


    public async Task<T> GetByIdAsync(long id)
        => await _dbSet.FindAsync(id);



    public async Task<int> SaveAsync()
       => await _appDbContext.SaveChangesAsync();

    public T Update(T entity)
        => _dbSet.Update(entity).Entity;
}
