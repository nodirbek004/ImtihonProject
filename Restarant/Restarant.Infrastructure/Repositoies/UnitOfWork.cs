using Restarant.Infrastructure.DbContexts;
using Restarant.Infrastructure.IRepositories;

namespace Restarant.Infrastructure.Repositoies;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext appDbContext;
    public IAdminRepository AdminRepository { get;  }
    public IWaiterRepository WaiterRepository { get; }
    public ICookRepository CookRepository { get; }
    public IClientRepository ClientRepository { get; }
    public UnitOfWork(AppDbContext dbContext)
    {
        this.appDbContext = dbContext;
        AdminRepository = new AdminRepository(dbContext);
        WaiterRepository= new WaiterRepository(dbContext);
        CookRepository = new CookRepository(dbContext);
        ClientRepository = new ClientRepository(dbContext);
        
    }

    public async Task<int> SaveAsync()
        => await this.appDbContext.SaveChangesAsync();
}
