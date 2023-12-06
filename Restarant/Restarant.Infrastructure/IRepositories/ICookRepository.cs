using Restarant.Domain.Entities;

namespace Restarant.Infrastructure.IRepositories;

public interface ICookRepository:IRepository<Cook>
{
    IQueryable<Cook> SearchByName(string name);
}
