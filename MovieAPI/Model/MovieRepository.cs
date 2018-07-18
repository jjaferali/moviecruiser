namespace MovieAPI.Model
{
    public static class MovieRepository
    {
        public static string BaseUrl { get; set; }// = "http://api.themoviedb.org/3/";
        public static string ApiKey { get; set; } //"api_key=84e747d123fcfd4d8bbd2792dc5bd306";
        public static string NowPlaying { get; set; }// = "movie/now_playing?";
    }
}
