using Moq;
using MovieAPI.Entity;
using MovieAPI.Repository;
using MovieAPI.Service;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MovieAPIUnitTestvieAPITest
{
    public class WatchListServiceTest
    {
        private readonly Mock<IWatchListRepository> mockWatchListRepository;

        public WatchListServiceTest()
        {
            mockWatchListRepository = new Mock<IWatchListRepository>();
        }

        [Fact]
        public void GetAll_ShouldReturnListOfWatchListAsExpected()
        {
            // Arrange
            mockWatchListRepository.Setup(x => x.GetAll()).Returns(this.GetMoviesList);
            var service = new WatchListService(mockWatchListRepository.Object);
            var expected = this.GetMoviesList().Count;

            // Act
            var actual = service.GetAll().Count();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_ShouldReturnWhishListAsExpected()
        {
            // Arrange 
            var expectedResult = this.GetMoviesList().First();
            mockWatchListRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(expectedResult);
            var service = new WatchListService(mockWatchListRepository.Object);

            // Act
            var actual = service.GetWatchListById(1);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedResult.Id, actual.Id);           
            Assert.Equal(expectedResult.Comments, actual.Comments);
        }

        [Fact]
        public void Save_WatchListAsExpected()
        {
            // Arrange 
            var expected = 1;
            var WatchList = new MovieList()
            {
                Id = 1,             
                Comments = "Good"
            };
            mockWatchListRepository.Setup(x => x.Save(It.IsAny<MovieList>())).Returns(expected);
            var service = new WatchListService(mockWatchListRepository.Object);

            // Act
            var actual = service.Save(WatchList);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Update_ShouldUpdateForValidId()
        {
            // Arrange
            var expected = 1;
            var WatchList = new MovieList()
            {
                Id = 1,                
                Comments = "Good"
            };

            this.mockWatchListRepository.Setup(x => x.Update(It.IsAny<MovieList>())).Returns(1);
            var service = new WatchListService(mockWatchListRepository.Object);

            // Act
            var actual = service.Update(WatchList);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_ShouldReturnTrueforVaildId()
        {
            // Arrange
            this.mockWatchListRepository.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);
            var service = new WatchListService(mockWatchListRepository.Object);

            // Act
            var actual = service.Delete(1);

            //Assert
            Assert.True(actual);
        }

        private List<MovieList> GetMoviesList()
        {
            return new List<MovieList> {
                new MovieList { Id=1,Title="Kaala",Release_date="07/06/2018",Vote_count=100,Vote_average=9.80,overview="Good" },
                new MovieList { Id=2,Title="Jurasic Word",Release_date="07/06/2018",Vote_count=80,Vote_average=5.50,overview="Good" }
            };
        }
    }
}
