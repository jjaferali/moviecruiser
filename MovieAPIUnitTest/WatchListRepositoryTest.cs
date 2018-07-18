namespace MovieAPIUnitTestvieAPITest
{
    using MovieAPI.Entity;
    using MovieAPI.Repository;
    using System.Linq;
    using Xunit;

    public class WatchListRepositoryTest : IClassFixture<DatabaseFixture>
    {
        private readonly IWatchListRepository WatchListRepository;
        private readonly DatabaseFixture databaseFixture;

        public WatchListRepositoryTest(DatabaseFixture fixture)
        {
            this.databaseFixture = fixture;
            this.WatchListRepository = new WatchListRepository(this.databaseFixture.dbContext);
        }

        [Fact]
        public void GetAllMoviesListAsExpected()
        {
            // Act
            var actual = this.WatchListRepository.GetAll().Count();

            // Assert
            var expected = this.databaseFixture.dbContext.MovieList.Count();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetByMovieIdAsExpected()
        {
            // Act
            var actual = this.WatchListRepository.Get(11);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(11, actual.Id);
        }

        [Fact]
        public void GetMovieforInvalidId()
        {
            // Act
            var actual = this.WatchListRepository.Get(5);

            // Assert
            Assert.Null(actual);
        }

        [Fact]
        public void InsertWatchListAsExpected()
        {
            // Arrange 
            var expected = 3;
            var WatchList = new MovieList()
            {
                Id = 4,
                Comments = "test"
               
            };

            // Act
            this.WatchListRepository.Save(WatchList);

            // Assert
            var actual = this.WatchListRepository.GetAll().Count();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UpdateWatchListForValidId()
        {
            // Arrange
            var WatchList = new MovieList()
            {
                Id=10,               
                Comments = "updated"
            };

            // Act
            var actual = this.WatchListRepository.Update(WatchList);

            // Assert
            Assert.Equal(1, actual);
        }


        [Fact]
        public void UpdateWatchListForInValidId()
        {
            // Arrange

            var WatchList = new MovieList()
            {
                Id = 15,               
                Comments = "updated"
            };

            // Act
            var actual = this.WatchListRepository.Update(WatchList);

            // Assert
            Assert.Equal(0, actual);
        }

        [Fact]
        public void DeleteWatchListforVaildId()
        {
            // Act
            var actual = this.WatchListRepository.Delete(10);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void DeleteWatchListforInVaildId()
        {
            // Act
            var actual = this.WatchListRepository.Delete(10000);

            // Assert
            Assert.False(actual);
        }
    }
}
