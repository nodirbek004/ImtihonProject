using Restarant.Domain.Entities;

namespace Restarant.Infrastructure.IRepositories;

public interface IWaiterRepository:IRepository<Waiter>
{
    Task<Waiter> GetByTelNumberAsync(string telNumber);
}
