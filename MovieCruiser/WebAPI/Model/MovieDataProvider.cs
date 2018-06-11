using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Model
{
    public class MovieDataProvider : IMovie
    {
        private string connectionstring = Database.Sqlconnectionstring;//"Initial Catalog=fsddb;Data Source=fsdpracserver.database.windows.net;user id=jaffer;password=password@123";


        //Environment.GetEnvironmentVariable("ConnectionString");


        [JsonProperty(PropertyName = "results")]

        public List<Movie> GetTMDBMovieslList { get; set; }


        public async Task<List<Movie>> GetMovieslList()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                await connection.OpenAsync();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand("select * from movie", connection);
                dr = await cmd.ExecuteReaderAsync();
                Movie obj;
                List<Movie> moviesobj = new List<Movie>();
                while (dr.Read())
                {
                    obj = new Movie();
                    obj.Comments = dr["Comments"].ToString();
                    obj.Vote_average = Convert.ToDouble(dr["Rating"]);
                    obj.Vote_count = Convert.ToInt32(dr["RatingCount"]);
                    obj.Release_date = (dr["ReleasingDate"]).ToString();               
                    obj.overview = dr["Overview"].ToString();                   
                    obj.Title = dr["Title"].ToString();
                    obj.Poster_path = dr["TitlePath"].ToString();
                    obj.id = Convert.ToInt32(dr["id"]);
                    obj.WatchList =  Convert.ToBoolean(dr["WatchList"]);
                    moviesobj.Add(obj);
                }

                return moviesobj;
            }
        }

        public async Task InsertMovies(int id,Movie movie)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                await connection.OpenAsync();               
                SqlCommand cmd = new SqlCommand("insert into movie(WatchList,id,Comments,Rating,RatingCount,ReleasingDate,Overview,Title,TitlePath)Values('" + movie.WatchList + "', Id='" + id + "','"+ movie.Comments+"','"+movie.Vote_average+ "','" + movie.Vote_count + "','" + movie.Release_date + "','" + movie.overview + "','" + movie.Title + "','" + movie.Poster_path + "')", connection);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteMovies(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                await connection.OpenAsync();              
                SqlCommand cmd = new SqlCommand("delete from  movie where Id='" + id + "')", connection);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateMovies(int id, Movie movie)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                await connection.OpenAsync();
                SqlCommand cmd = new SqlCommand("update movie set Comments='"+movie.Comments+"' where Id='"+id+"'", connection);
                await cmd.ExecuteNonQueryAsync();
            }
        }

       
    }
}
