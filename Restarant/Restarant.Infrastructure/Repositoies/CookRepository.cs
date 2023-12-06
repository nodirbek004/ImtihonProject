using Restarant.Domain.Entities;
using Restarant.Infrastructure.DbContexts;
using Restarant.Infrastructure.IRepositories;

namespace Restarant.Infrastructure.Repositoies;

public class CookRepository:Repositories<Cook>,ICookRepository
{
    public CookRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public IQueryable<Cook> SearchByName(string name)
        => _appDbContext.Cooks.Where(p => p.FirstName.Contains(name)).AsQueryable();
}
