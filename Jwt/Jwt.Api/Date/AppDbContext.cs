using Jwt.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Authtorisation.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=jwtDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
            public DbSet<User> Users { get; set; }
    }
}
