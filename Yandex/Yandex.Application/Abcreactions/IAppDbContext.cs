using Microsoft.EntityFrameworkCore;
using Yandex.Domain.Entities;

namespace Yandex.Application.Abcreactions;

public interface IAppDbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Card> Cards { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
