namespace MovieAPI.Entity
{
    using Microsoft.EntityFrameworkCore;

    public interface IMovieDbContext
    {
        DbSet<MovieList> MovieList { get; set; }

        int SaveChanges();
    }
}
