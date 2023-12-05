using HospitalInformationSystem.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Infrastructure.Contexts;
using Poliklinika.Infrastructure.IRepasitories;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Poliklinika.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : Auditable
{
    public readonly AppDbContext _appDbContext;
    private readonly DbSet<T> _dbSet;


    public Repository(AppDbContext appDbContext)
    {
        this._appDbContext = appDbContext;
        _dbSet = appDbContext.Set<T>();
    }

    public Repository(AppDbContext appDbContext,DbSet<T> dbSet)
    {
        _appDbContext = appDbContext;
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
        =>_dbSet.AsQueryable();


    public async Task<T> GetByIdAsync(long id)
        =>await _dbSet.FindAsync(id);



    public async Task<int> SaveAsync()
       => await _appDbContext.SaveChangesAsync();

    public T Update(T entity)
        => _dbSet.Update(entity).Entity;
}
