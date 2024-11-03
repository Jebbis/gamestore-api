using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Entities.Game> Games => Set<Entities.Game>();
    public DbSet<Entities.Genre> Genres => Set<Entities.Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Entities.Genre>()
            .HasData(
                new { Id = 1, Name = "Fighting" },
                new { Id = 2, Name = "Roleplaying" },
                new { Id = 3, Name = "Sports" },
                new { Id = 4, Name = "Racing" },
                new { Id = 5, Name = "Kids and Family" }
            );
    }
}
