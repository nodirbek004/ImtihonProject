using Microsoft.EntityFrameworkCore;
using Restarant.Domain.Entities;

namespace Restarant.Infrastructure.DbContexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
       
    }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Cook> Cooks { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Waiter> Waiters { get; set; }
}
