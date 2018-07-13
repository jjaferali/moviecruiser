using Moq;
using MovieAPI.Model;
using MovieAPI.Repository;
using MovieAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var actual = service.GetWhisListById(1);

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
            var WatchList = new WatchListDetails()
            {
                Id = 1,             
                Comments = "Good"
            };
            mockWatchListRepository.Setup(x => x.Save(It.IsAny<WatchListDetails>())).Returns(expected);
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
            var WatchList = new WatchListDetails()
            {
                Id = 1,                
                Comments = "Good"
            };

            this.mockWatchListRepository.Setup(x => x.update(It.IsAny<WatchListDetails>())).Returns(1);
            var service = new WatchListService(mockWatchListRepository.Object);

            // Act
            var actual = service.update(WatchList);

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

        private List<WatchListDetails> GetMoviesList()
        {
            return new List<WatchListDetails> {
                new WatchListDetails { Id=1,MovieName="Kaala",ReleaseDate="07/06/2018",VoteCount=100,VoteAverage=9.80,Overview="Good" },
                new WatchListDetails { Id=2,MovieName="Jurasic Word",ReleaseDate="07/06/2018",VoteCount=80,VoteAverage=5.50,Overview="Good" }
            };
        }
    }
}
