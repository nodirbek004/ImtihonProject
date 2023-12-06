using Restarant.Domain.Entities;

namespace Restarant.Infrastructure.IRepositories;

public interface IClientRepository:IRepository<Client>
{
    Task<Client> GetByTelNumberAsync(string telNumber);
}
