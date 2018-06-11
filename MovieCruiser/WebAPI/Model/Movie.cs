using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Model
{
   
    public class Movie
    {       
        public string Comments { get; set; }
        public bool WatchList { get; set; }
        [JsonProperty(PropertyName = "poster_path")]
        public string Poster_path { get; set; }
        [JsonProperty(PropertyName = "overview")]
        public string overview { get; set; }
        [JsonProperty(PropertyName = "release_date")]
        public string Release_date { get; set; }
        [JsonProperty(PropertyName = "genre_ids")]
        public int[] genre_ids { get; set; }
        [JsonProperty(PropertyName = "id")]
        [JsonRequired]
        public int id { get; set; }
        [JsonProperty(PropertyName = "original_title")]
        public string Original_title { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "vote_count")]
        public int Vote_count { get; set; }
        [JsonProperty(PropertyName = "vote_average")]
        public double Vote_average { get; set; }
        [JsonProperty(PropertyName = "popularity")]
        public double Popularity { get; set; }



    }
}
