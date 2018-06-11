using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Model
{
    public interface IMovie
    {
      
        Task InsertMovies (int id,Movie movie);
        Task UpdateMovies(int id, Movie movie);
        Task DeleteMovies(int id);
        [JsonProperty(PropertyName = "results")]
        List<Movie> GetTMDBMovieslList { get; set; }
        Task<List<Movie>> GetMovieslList();


    }
}
