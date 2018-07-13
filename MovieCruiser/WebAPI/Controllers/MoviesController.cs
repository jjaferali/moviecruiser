namespace MovieAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MovieAPI.Entity;
    using MovieAPI.Model;
    using MovieAPI.Repository;
    using MovieAPI.Service;
    using Newtonsoft.Json;

    [Route("api/Movies")]
    [Authorize]
    public class MoviesController : Controller
    {
        private IWatchListService service;

        /// <summary>
        /// Initialize IWatchListService service
        /// </summary>
        /// <param name="service"></param>
        public MoviesController(IWatchListService service)
        {
            this.service = service;
        }


        // GET api/values
        [HttpGet]
        [Route("TMDB")]
        public async Task<IEnumerable<MovieList>> GetTMDB()
        {           
            return service.GetTMDBMovieslList;
        }

        /// <summary>
        /// Get all Watch list
        /// </summary>
        /// <returns>list of WatchListDetails</returns>
        // GET: api/WatchList
        [HttpGet]
        public IEnumerable<WatchListDetails> Get()
        {
            return this.service.GetAll();
        }

      
        // GET: api/WatchList/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var WatchListDetails = this.service.GetWhisListById(id);

            if (WatchListDetails == null)
            {
                return NotFound();
            }

            return Ok(WatchListDetails);
        }

       
        // add Watchlist       
        // PUT: api/WatchList/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] WatchListDetails WatchListDetails)
        {
            if (id != WatchListDetails.Id)
            {
                return BadRequest();
            }

            try
            {
                var result = this.service.update(WatchListDetails);

                if (result == 0)
                {
                    return NotFound();
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Update WatchList
        // POST: api/WatchList
        [HttpPost]
        public IActionResult Post([FromBody] WatchListDetails WatchListDetails)
        {
            try
            {
                var result = this.service.Save(WatchListDetails);
                if (result == 409)
                {
                    return StatusCode(409);
                }

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/WatchList/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = this.service.Delete(id);

            if (result)
            {
                return Ok(result);
            }

            return NotFound(500);
        }
    }
}