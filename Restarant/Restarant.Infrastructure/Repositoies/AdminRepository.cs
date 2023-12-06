using Microsoft.EntityFrameworkCore;
using Restarant.Domain.Entities;
using Restarant.Infrastructure.DbContexts;
using Restarant.Infrastructure.IRepositories;

namespace Restarant.Infrastructure.Repositoies;

public class AdminRepository : Repositories<Admin>, IAdminRepository
{
    public AdminRepository(AppDbContext appContext) : base(appContext)
    {
    }
    public async Task<Admin> GetByTelNumberAsync(string telNumber)
           => await _appDbContext.Admins.FirstOrDefaultAsync(t => t.PhoneNumber.Equals(telNumber));

}
