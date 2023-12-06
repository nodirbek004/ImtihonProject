using Microsoft.EntityFrameworkCore;
using Restarant.Domain.Entities;
using Restarant.Infrastructure.DbContexts;
using Restarant.Infrastructure.IRepositories;

namespace Restarant.Infrastructure.Repositoies;

public class WaiterRepository:Repositories<Waiter>,IWaiterRepository
{
    public WaiterRepository(AppDbContext appContext) : base(appContext)
    {
    }
    public async Task<Waiter> GetByTelNumberAsync(string telNumber)
          => await _appDbContext.Waiters.FirstOrDefaultAsync(t => t.PhoneNumber.Equals(telNumber));

}
