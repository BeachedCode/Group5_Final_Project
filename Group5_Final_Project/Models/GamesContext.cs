using Microsoft.EntityFrameworkCore;

namespace Group5_Final_Project.Models
{
    public class GamesContext : DbContext
    {
        public GamesContext(DbContextOptions<GamesContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameGenre> Genres { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>().HasData(
                new Developer { Id = 1, Name = "Nintendo", Location = "Japan" },
                new Developer { Id = 2, Name = "Sony", Location = "Japan" },
                new Developer { Id = 3, Name = "Microsoft", Location = "America"},
                new Developer{ Id = 4, Name = "Naughty Dog", Location = "America"}  
                   
                );

            modelBuilder.Entity<GameGenre>().HasData(
                new GameGenre { Id = 1, Genre = "RPG" },
                new GameGenre { Id = 2, Genre = "Adventure" },
                new GameGenre { Id = 3, Genre = "Strategy" },
                new GameGenre { Id = 4, Genre = "Action" }
                );

            modelBuilder.Entity<Platform>().HasData(
                new Platform { Id = 1, Name = "Nintendo Switch" },
                new Platform { Id = 2, Name = "Playstation 5" },
                new Platform { Id = 3, Name = "Xbox Series X" },
                new Platform { Id = 4, Name = "Playstation 4" }
                );
            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Name = "The Legend of Zelda: Breath of the Wild", GenreId = 2, DeveloperId = 1, ReleaseDate = new DateOnly(2017, 3, 3), Rating = 10 },
                new Game { Id = 2, Name = "The Last of Us Part II", GenreId = 4, DeveloperId = 4, ReleaseDate = new DateOnly(2020, 6, 19),Rating = 9 },
                new Game { Id = 3, Name = "Halo Infinite", GenreId = 4, DeveloperId = 3, ReleaseDate = new DateOnly(2021, 12, 8), Rating = 8 }
                );
        }


    }
}
