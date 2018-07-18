namespace MovieAPI.Repository
{
    using MovieAPI.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class WatchListRepository : IWatchListRepository
    {
        private IMovieDbContext _context;

        public WatchListRepository(IMovieDbContext context)
        {
            this._context = context;
        }
        [JsonProperty(PropertyName = "results")]
        public IList<MovieList> GetTMDBMovieslList { get; set; }



        /// <summary>
        /// Get all Watchlist 
        /// </summary>
        /// <returns></returns>
        public IList<MovieList> GetAll()
        {
            return this._context.MovieList.ToList();
        }

        /// <summary>
        /// Get Watchlist 
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>WatchListDetails</returns>
        public MovieList Get(int id)
        {
            var response = this._context.MovieList.FirstOrDefault(x => x.Id == id);

            if (response == null)
            {
                return null;
            }

            return response;

        }

        /// <summary>
        /// Add Watchlist 
        /// </summary>
        /// <param name="watchListDetails">WatchListDetails</param>
        /// <returns>integer</returns>
        public int Save(MovieList WatchListDetails)
        {
            bool existMovie = this._context.MovieList.Any(x => x.Id == WatchListDetails.Id);

            if (existMovie)
            {
                return 409;
            }           
            this._context.MovieList.Add(WatchListDetails);
            return this._context.SaveChanges();
        }

        /// <summary>
        /// Update the Watchlist
        /// </summary>
        /// <param name="watchListDetails"></param>
        /// <returns></returns>
        public int Update(MovieList WatchListDetails)
        {
            var watchList = this._context.MovieList.FirstOrDefault(x => x.Id == WatchListDetails.Id);
            if (watchList != null)
            {
                watchList.Comments = WatchListDetails.Comments;               
                return this._context.SaveChanges();
            }

            return 0;
        }

        /// <summary>
        /// Delete the Watchlist
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>boolean </returns>
        public bool Delete(int id)
        {
            var response = this._context.MovieList.Find(id);

            if (response != null)
            {
                this._context.MovieList.Remove(response);
                this._context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
