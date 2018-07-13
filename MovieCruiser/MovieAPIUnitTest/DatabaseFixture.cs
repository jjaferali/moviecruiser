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
            dbContext.MovieList.Add(new MovieList { Id = 10, Comments = "first" });
            dbContext.MovieList.Add(new MovieList { Id = 11, Comments = "second" });
            dbContext.MovieList.Add(new MovieList { Id = 12, Comments = "third" });
        }

        public void Dispose()
        {
            MovieList = null;
            dbContext = null;
        }
    }
}
