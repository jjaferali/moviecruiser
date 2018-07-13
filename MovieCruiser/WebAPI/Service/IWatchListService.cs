namespace MovieAPI.Service
{
    using MovieAPI.Entity;
    using MovieAPI.Model;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public interface IWatchListService
    {
        IList<WatchListDetails> GetAll();

        [JsonProperty(PropertyName = "results")]
        IList<MovieList> GetTMDBMovieslList { get; set; }

        WatchListDetails GetWhisListById(int id);

        int update(WatchListDetails watchListDetails);

        int Save(WatchListDetails watchListDetails);

        bool Delete(int id);
    }
}
