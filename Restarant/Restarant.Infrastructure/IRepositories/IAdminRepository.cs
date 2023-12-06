using Restarant.Domain.Entities;

namespace Restarant.Infrastructure.IRepositories;

public interface IAdminRepository:IRepository<Admin>
{
    Task<Admin> GetByTelNumberAsync(string telNumber);
}
