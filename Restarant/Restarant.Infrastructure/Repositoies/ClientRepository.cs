using Microsoft.EntityFrameworkCore;
using Restarant.Domain.Entities;
using Restarant.Infrastructure.DbContexts;
using Restarant.Infrastructure.IRepositories;

namespace Restarant.Infrastructure.Repositoies;

public class ClientRepository:Repositories<Client>,IClientRepository
{
    public ClientRepository(AppDbContext appContext) : base(appContext)
    {

    }
    public async Task<Client> GetByTelNumberAsync(string telNumber)
          => await _appDbContext.Clients.FirstOrDefaultAsync(t => t.PhoneNumber.Equals(telNumber));

}
