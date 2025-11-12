using gamesstore.Domain;
using Microsoft.EntityFrameworkCore;

namespace gamesstore.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
