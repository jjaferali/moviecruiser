using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MovieAPI.Model;

namespace WebApplication1
{
    public class Startup
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
           
            services.AddTransient<IMovie, MovieDataProvider>();
            Database.Sqlconnectionstring=((ConfigurationSection)(Configuration.GetSection("ConnectionString").GetSection("Sqlconnectionstring"))).Value;
            MovieRepository.BaseUrl=((ConfigurationSection)(Configuration.GetSection("TMDB").GetSection("BaseUrl"))).Value;
            MovieRepository.ApiKey = ((ConfigurationSection)(Configuration.GetSection("TMDB").GetSection("ApiKey"))).Value;
            MovieRepository.NowPlaying = ((ConfigurationSection)(Configuration.GetSection("TMDB").GetSection("NowPlaying"))).Value;
            services.AddMvc();

        }

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }

            app.UseMvc(routes=> {
                routes.MapRoute(name: "default", template: "{ controller=Movies}/{action=GetMovies}/{id?}");
            });
                   }
    }
}
