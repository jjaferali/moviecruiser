namespace MovieAPI.Service
{
    using MovieAPI.Entity;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public interface IWatchListService
    {
        IList<MovieList> GetAll();

        [JsonProperty(PropertyName = "results")]
        IList<MovieList> GetTMDBMovieslList { get; set; }

        MovieList GetWatchListById(int id);

        int Update(MovieList watchListDetails);

        int Save(MovieList watchListDetails);

        bool Delete(int id);
    }
}
