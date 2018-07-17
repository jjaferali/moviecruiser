namespace MovieAPI.Repository
{
    using MovieAPI.Entity;
    using MovieAPI.Model;
    using System.Linq;
    using System.Collections.Generic;
    using System;
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
        public IList<WatchListDetails> GetAll()
        {
            return this._context.MovieList.Select(x => new WatchListDetails
            {
                Id = x.Id,                
                MovieName = x.Title,
                PosterPath = x.Poster_path,
                ReleaseDate = x.Release_date,
                VoteAverage = x.Vote_average,
                VoteCount = x.Vote_count,
                Overview = x.overview,
                Comments = x.Comments
            }).ToList();
        }

        /// <summary>
        /// Get Watchlist 
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>WatchListDetails</returns>
        public WatchListDetails Get(int id)
        {
            var response = this._context.MovieList.FirstOrDefault(x => x.Id == id);

            if (response == null)
            {
                return null;
            }

            return new WatchListDetails
            {

                Comments = response.Comments,
                Id = response.Id,
                MovieName = response.Title,
                VoteAverage = response.Vote_average,
                PosterPath = response.Poster_path,
                VoteCount = response.Vote_count,
                Overview = response.overview,
                ReleaseDate = response.Release_date,
            };
        }

        /// <summary>
        /// Add Watchlist 
        /// </summary>
        /// <param name="watchListDetails">WatchListDetails</param>
        /// <returns>integer</returns>
        public int Save(WatchListDetails WatchListDetails)
        {
            bool existMovie = this._context.MovieList.Any(x => x.Id == WatchListDetails.Id);

            if (existMovie)
            {
                return 409;
            }

            var watchList = new MovieList()
            {
                Comments = WatchListDetails.Comments,
                Id = WatchListDetails.Id,
                Title = WatchListDetails.MovieName,
                Vote_average = WatchListDetails.VoteAverage,
                Poster_path = WatchListDetails.PosterPath,
                Vote_count = WatchListDetails.VoteCount,
                overview = WatchListDetails.Overview,
                Release_date = WatchListDetails.ReleaseDate,               
            };

            this._context.MovieList.Add(watchList);
            return this._context.SaveChanges();
        }

        /// <summary>
        /// update the Watchlist
        /// </summary>
        /// <param name="watchListDetails"></param>
        /// <returns></returns>
        public int update(WatchListDetails WatchListDetails)
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
