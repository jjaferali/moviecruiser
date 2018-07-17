namespace MovieAPIUnitTestvieAPITest
{
    using Microsoft.EntityFrameworkCore;
    using MovieAPI.Entity;
    using System;
    using System.Collections.Generic;

    public class DatabaseFixture : IDisposable
    {
        private IList<MovieList> MovieList { get; set; }
        public IMovieDbContext dbContext;

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<MovieDbContext>().UseInMemoryDatabase(databaseName: "MovieCruiser").Options;
            dbContext = new MovieDbContext(options);

            // Mock data
            dbContext.MovieList.Add(new MovieList { Id = 10, Title = "Kaala", Comments = "Good" });
            dbContext.MovieList.Add(new MovieList { Id = 11, Title = "Jurasic Word", Comments = "Better" });
            dbContext.MovieList.Add(new MovieList { Id = 12, Title="2.0", Comments = "Best" });
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            MovieList = null;
            dbContext = null;
        }
    }
}
