namespace MovieAPI.Service
{
    using MovieAPI.Entity;
    using MovieAPI.Model;
    using MovieAPI.Repository;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class WatchListService : IWatchListService
    {
        public IWatchListRepository repository;

        [JsonProperty(PropertyName = "results")]
        public IList<MovieList> GetTMDBMovieslList { get; set; }

        public WatchListService(IWatchListRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get all Movie TMDB details
        /// </summary>
        /// <returns>list of WatchListDetails</returns>
        public async Task<IEnumerable<MovieList>> GetTMDB()
        {

            var baseAddress = new Uri(MovieRepository.BaseUrl);
            var movieList = new MovieList();
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                using (var response = await httpClient.GetAsync(MovieRepository.NowPlaying + MovieRepository.ApiKey + "&page=1"))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    movieList = JsonConvert.DeserializeObject<MovieList>(responseData);

                }
            }
            return repository.GetTMDBMovieslList;
        }
        /// <summary>
        /// Get all Watchlist details
        /// </summary>
        /// <returns>list of WatchListDetails</returns>
        public IList<MovieList> GetAll()
        {
           return this.repository.GetAll();
        }

        /// <summary>
        /// Delete the watch list
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>boolean </returns>
        public bool Delete(int id)
        {
            return this.repository.Delete(id);
        }

        /// <summary>
        /// Get Watchlist details
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>WatchListDetails</returns>
        public MovieList GetWatchListById(int id)
        {
            return this.repository.Get(id);
        }

        /// <summary>
        /// Add WatchList 
        /// </summary>
        /// <param name="watchListDetails"></param>
        /// <returns>WatchListDetails</returns>
        public int Save(MovieList watchListDetails)
        {
            return this.repository.Save(watchListDetails);
        }

        /// <summary>
        /// Update the WatchListDetails
        /// </summary>
        /// <param name="watchListDetails"></param>
        /// <returns>integer</returns>
        public int Update(MovieList watchListDetails)
        {
            return this.repository.Update(watchListDetails);
        }
    }
}
