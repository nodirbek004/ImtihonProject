using Microsoft.EntityFrameworkCore;
using Yandex.Application.Abcreactions;
using Yandex.Domain.Entities;

namespace Yandex.Infrastructure.Persistance;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Card> Cards { get; set; }


}
