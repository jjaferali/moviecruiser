using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieAPI.Controllers;
using MovieAPI.Entity;
using MovieAPI.Service;
using System.Collections.Generic;
using Xunit;

namespace MovieAPIUnitTestvieAPITest
{

    public class MoviesControllerTest
    {
        
        [Fact]
        public void GetMoviesListTMDBTest()
        {
           
            var mockIMovies = new Mock<IWatchListService>();

            mockIMovies.Setup(service => service.GetTMDBMovieslList).Returns(GetMoviesList());

            var movieController = new MoviesController(mockIMovies.Object);

            var result = movieController.GetTMDB().Result as List<MovieList>;

            //Assert
            Assert.Equal(2, result.Count);


        }

        [Fact]
        public void GetMovieByIdTest()
        {
            var mockIMovies = new Mock<IWatchListService>();
            mockIMovies.Setup(service => service.GetAll()).Returns(GetMoviesList());
            var movieController = new MoviesController(mockIMovies.Object);
          
            // Act
            var result = movieController.Get();
            var actualResult = result as List<MovieList>;
            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, actualResult.Count);
        }

        [Fact]
        public void GetMoviesForInvalidId()
        {
            var mockIMovies = new Mock<IWatchListService>();
            mockIMovies.Setup(service => service.GetAll()).Returns(GetMoviesList());
            // Arrange 
            var controller = new MoviesController(mockIMovies.Object);

            // Act
            var result = controller.Get(458955) as NotFoundResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }


        [Fact]
        public void InsertMovieTest()
        {
            var mockIMovies = new Mock<IWatchListService>();
            mockIMovies.Setup(service => service.GetAll()).Returns(GetMoviesList());
            var movieController = new MoviesController(mockIMovies.Object);
            var movieobj = new MovieList { Id = 3, Title = "IrumbuThirai", Release_date = "07/06/2018", Vote_count = 100, Vote_average = 9.80, overview = "Good" };

            // Act
            var result = movieController.Post(movieobj) as StatusCodeResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
        }


        [Fact]
        public void UpdateMovieTest()
        {
            var expected = 1;
            var mockIMovies = new Mock<IWatchListService>();
            mockIMovies.Setup(x => x.Update(It.IsAny<MovieList>())).Returns(1);           
            var movieController = new MoviesController(mockIMovies.Object);
            var movieobj = new MovieList { Id =2,Comments="Good Movie" };
           
            // Act
            var result = movieController.Put(2, movieobj) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expected, actualResult);

                    
        }

        [Fact]
        public void UpdateMovieForInValidId()
        {
            
            var mockIMovies = new Mock<IWatchListService>();
            mockIMovies.Setup(x => x.Update(It.IsAny<MovieList>())).Returns(1);
            var movieController = new MoviesController(mockIMovies.Object);
            var  movieobj = new MovieList { Id = 3, Comments = "Good Movie" };

            // Act
            var result = movieController.Put(4, movieobj) as BadRequestResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }


        [Fact]
        public void DeleteMovieTest()
        {
            var mockIMovies = new Mock<IWatchListService>();
            mockIMovies.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);
            var movieController = new MoviesController(mockIMovies.Object);            
           
            // Act
            var result = movieController.Delete(2) as OkObjectResult;
            var actualResult = (bool)result.Value;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.True(actualResult);
        }


        [Fact]
        public void DeleteForInVaildId()
        {
            var mockIMovies = new Mock<IWatchListService>();
            mockIMovies.Setup(x => x.Delete(It.IsAny<int>())).Returns(false);
            var movieController = new MoviesController(mockIMovies.Object);
            // Act
            var result = movieController.Delete(4) as NotFoundObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);

        }

        private  IList<MovieList> GetMoviesList()
        {
            return new List<MovieList> {
                new MovieList { Id=1,Title="Kaala",Release_date="07/06/2018",Vote_count=100,Vote_average=9.80,overview="Good" },
                new MovieList { Id=2,Title="Jurasic Word",Release_date="07/06/2018",Vote_count=80,Vote_average=5.50,overview="Good" }
            };
        }

       
    }
}
