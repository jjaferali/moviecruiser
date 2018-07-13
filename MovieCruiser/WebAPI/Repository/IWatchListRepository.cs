namespace MovieAPI.Repository
{
    using MovieAPI.Entity;
    using MovieAPI.Model;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public interface IWatchListRepository
    {
        IList<WatchListDetails> GetAll();

        [JsonProperty(PropertyName = "results")]
        IList<MovieList> GetTMDBMovieslList { get; set; }

        WatchListDetails Get(int id);

        int update(WatchListDetails watchListDetails);

        int Save(WatchListDetails watchListDetails);

        bool Delete(int id);


    }
}
