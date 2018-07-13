﻿namespace MovieAPIUnitTestvieAPITest
{
    using MovieAPI.Model;
    using MovieAPI.Repository;
    using System;
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
        public void GetAll_ShouldReturnListOfWatchListAsExpected()
        {
            // Act
            var actual = this.WatchListRepository.GetAll().Count();

            // Assert
            var expected = this.databaseFixture.dbContext.MovieList.Count();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_ShouldReturnWhishListAsExpected()
        {
            // Act
            var actual = this.WatchListRepository.Get(11);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(11, actual.Id);
        }

        [Fact]
        public void Get_ShouldReturnNullforInvalidId()
        {
            // Act
            var actual = this.WatchListRepository.Get(5);

            // Assert
            Assert.Null(actual);
        }

        [Fact]
        public void Save_WatchListAsExpected()
        {
            // Arrange 
            var expected = 4;
            var WatchList = new WatchListDetails()
            {
                Id = 408,
                Comments = "test"
               
            };

            // Act
            this.WatchListRepository.Save(WatchList);

            // Assert
            var actual = this.databaseFixture.dbContext.MovieList.Count();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ShouldUpdateForValidId()
        {
            // Arrange
            var WatchList = new WatchListDetails()
            {
                Id=10,               
                Comments = "updated"
            };

            // Act
            var actual = this.WatchListRepository.update(WatchList);

            // Assert
            Assert.Equal(1, actual);
        }


        [Fact]
        public void Update_ShouldNotUpdateForInValidId()
        {
            // Arrange

            var WatchList = new WatchListDetails()
            {
                Id = 15,               
                Comments = "updated"
            };

            // Act
            var actual = this.WatchListRepository.update(WatchList);

            // Assert
            Assert.Equal(0, actual);
        }

        [Fact]
        public void Delete_ShouldRemoveforVaildId()
        {
            // Act
            var actual = this.WatchListRepository.Delete(10);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void Delete_ShouldNotRemoveforInVaildId()
        {
            // Act
            var actual = this.WatchListRepository.Delete(10000);

            // Assert
            Assert.False(actual);
        }
    }
}
