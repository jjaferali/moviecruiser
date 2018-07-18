using System;
using Microex.Swagger.Application;
using Microex.Swagger.SwaggerGen.Application;
using Microex.Swagger.SwaggerGen.Model;
using Microex.Swagger.SwaggerUI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieAPI.Entity;
using MovieAPI.Model;
using MovieAPI.Repository;
using MovieAPI.Service;

namespace MovieCruiser
{
    public partial class Startup
    {
        public static string ConnectionString { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {          
          
            // JWT
            ConfigureJwtAuthService(Configuration, services);

           
            // Connection string
            string connectionString = Environment.GetEnvironmentVariable("SQL_AUTH");
            MovieRepository.BaseUrl = Environment.GetEnvironmentVariable("BaseUrl");
            MovieRepository.ApiKey = Environment.GetEnvironmentVariable("ApiKey");
            MovieRepository.NowPlaying = Environment.GetEnvironmentVariable("NowPlaying");
            //Dependency injection
            if (string.IsNullOrEmpty(connectionString))
                connectionString =  ((ConfigurationSection)(Configuration.GetSection("ConnectionString").GetSection("DefaultConnection"))).Value;
            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IMovieDbContext>(provider => provider.GetService<MovieDbContext>());
            services.AddScoped<IWatchListRepository, WatchListRepository>();
            services.AddScoped<IWatchListService, WatchListService>();

            // Swagger Setup
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Info { Version = "v1.0", Title = "MovieCruiser API" });
            });

            services.AddMvc();
        }

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }

            app.UseSwagger();
            app.UseSwaggerUI3(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "moviecruiser api v1.0");
            });

          
            app.UseAuthentication();


            app.UseMvc(routes=> {
                routes.MapRoute(name: "default", template: "{ controller=Movies}/{action=GetMovies}/{id?}");
            });
                   }
    }
}
