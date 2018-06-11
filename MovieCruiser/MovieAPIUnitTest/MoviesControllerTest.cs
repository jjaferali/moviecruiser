using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieAPI.Controllers;
using MovieAPI.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MovieAPIUnitTestvieAPITest
{
    
    public class MoviesControllerTest
    {
        [Fact]
        public void GetMoviesListTMDBTest()
        {
            var mockIMovies = new Mock<IMovie>();

            mockIMovies.Setup(service => service.GetTMDBMovieslList);

            var movieController = new MoviesController(mockIMovies.Object);

            Assert.NotNull(movieController.Get());
          
        }

        [Fact]
        public void GetMovieByIdTest()
        {
            var mockIMovies = new Mock<IMovie>();
            mockIMovies.Setup(service => service.GetMovieslList()).Returns(GetMoviesListAsync());
            var movieController = new MoviesController(mockIMovies.Object);
            var result = Assert.IsType<OkObjectResult>(movieController.Get(1).Result);
        }


        [Fact]
        public void InsertMovieTest()
        {
            var mockIMovies = new Mock<IMovie>();
            mockIMovies.Setup(service => service.GetMovieslList()).Returns(GetMoviesListAsync());
            var movieController = new MoviesController(mockIMovies.Object);
            var movieobj = new Movie { id = 3, Title = "IrumbuThirai", Release_date = "07/06/2018", Vote_count = 100, Vote_average = 9.80, overview = "Good" };
            var result = Assert.IsType<OkObjectResult>(movieController.Post(3, movieobj).Result);
            
        }


        [Fact]
        public void UpdateMovieTest()
        {
            var mockIMovies = new Mock<IMovie>();
            mockIMovies.Setup(service => service.GetMovieslList()).Returns(GetMoviesListAsync());
            var movieController = new MoviesController(mockIMovies.Object);
            var movieobj = new Movie { id = 2,Comments="Good Movie" };
            var okResult = Assert.IsType<OkResult>(movieController.Put(2, movieobj).Result);

            movieobj = new Movie { id = 3, Comments = "Good Movie" };
            var result = Assert.IsType<NotFoundObjectResult> (movieController.Put(3, movieobj).Result);
           
        }


        [Fact]
        public void DeleteMovieTest()
        {
            var mockIMovies = new Mock<IMovie>();
            mockIMovies.Setup(service => service.GetMovieslList()).Returns(GetMoviesListAsync());
            var movieController = new MoviesController(mockIMovies.Object);            
            var OkResult = Assert.IsType<OkResult>(movieController.Delete(2).Result);

            var result = Assert.IsType<NotFoundObjectResult>(movieController.Delete(4).Result);
        }
            

        private async Task<List<Movie>> GetMoviesListAsync()
        {
          return new  List<Movie> {
                new Movie { id=1,Title="Kaala",Release_date="07/06/2018",Vote_count=100,Vote_average=9.80,overview="Good" },
                new Movie { id=2,Title="Jurasic Word",Release_date="07/06/2018",Vote_count=80,Vote_average=5.50,overview="Good" }
            };
        }

    }
}
