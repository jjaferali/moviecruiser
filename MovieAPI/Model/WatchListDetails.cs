namespace MovieAPI.Model
{
    using System;

    public class WatchListDetails
    {
        public int Id { get; set; }      

        public string MovieName { get; set; }

        public string Comments { get; set; }

        public string PosterPath { get; set; }

        public double VoteAverage { get; set; }

        public int VoteCount { get; set; }

        public string Overview { get; set; }

        public string ReleaseDate { get; set; }

      
    }
}
