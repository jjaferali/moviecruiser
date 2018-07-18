namespace MovieAPI.Repository
{
    using MovieAPI.Entity;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public interface IWatchListRepository
    {
        IList<MovieList> GetAll();

        [JsonProperty(PropertyName = "results")]
        IList<MovieList> GetTMDBMovieslList { get; set; }

        MovieList Get(int id);

        int Update(MovieList watchListDetails);

        int Save(MovieList watchListDetails);

        bool Delete(int id);


    }
}
