using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAPI.Migrations
{
    public partial class MovieAPIEntityMovieDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Original_title = table.Column<string>(nullable: true),
                    Popularity = table.Column<double>(nullable: false),
                    Poster_path = table.Column<string>(nullable: true),
                    Release_date = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Vote_average = table.Column<double>(nullable: false),
                    Vote_count = table.Column<int>(nullable: false),
                    WatchList = table.Column<bool>(nullable: false),
                    overview = table.Column<string>(nullable: true)
                }             
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieList");
        }
    }
}
