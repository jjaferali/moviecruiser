using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Model;
using Newtonsoft.Json;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller

    {
        private IMovie obj;     

        public MoviesController(IMovie _obj)
        {
            this.obj = _obj;
        }
     
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Movie>> Get()
        {

            var baseAddress = new Uri(MovieRepository.BaseUrl);           
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                using (var response = await httpClient.GetAsync(MovieRepository.NowPlaying + MovieRepository.ApiKey + "&page=1"))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                     obj = JsonConvert.DeserializeObject<MovieDataProvider>(responseData);
                    
                }
            }
            return obj.GetTMDBMovieslList; 
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if ((await obj.GetMovieslList()).All(a => a.id != id))
            {
                return NotFound(id);
            }
            return Ok((await obj.GetMovieslList()).Where(a => a.id == id).FirstOrDefault());
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(int id, Movie movie)
        {
            if (!ModelState.IsValid)
             return BadRequest(ModelState);             
            await obj.InsertMovies(id, movie);
            return Ok(movie);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Movie movie)
        {
            if ((await obj.GetMovieslList()).All(a => a.id != id))
            {
                return NotFound(id);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            movie.id = id;
            await obj.UpdateMovies(id,movie);
            return Ok();
              
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await obj.GetMovieslList()).All(a => a.id != id))
            {
                return NotFound(id);
            }
            await obj.DeleteMovies(id);
            return Ok();
        }
    }
}
