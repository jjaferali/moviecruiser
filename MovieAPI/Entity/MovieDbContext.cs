namespace MovieAPI.Entity
{
    using Microsoft.EntityFrameworkCore;

    public class MovieDbContext : DbContext, IMovieDbContext
    {
        public MovieDbContext() { }

        public MovieDbContext(DbContextOptions<MovieDbContext> contextOptions) : base(contextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<MovieList> MovieList { get; set; }
    }
}
