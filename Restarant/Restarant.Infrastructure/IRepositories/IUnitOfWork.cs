namespace Restarant.Infrastructure.IRepositories;

public interface IUnitOfWork
{
    IAdminRepository AdminRepository { get;  }
    IClientRepository ClientRepository { get;  }
    ICookRepository CookRepository { get; }
    IWaiterRepository WaiterRepository { get; }
    Task<int> SaveAsync();
}
