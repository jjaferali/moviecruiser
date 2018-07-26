using System;
using JWTAuthServer.Data.Persistence;
using JWTAuthServer.Services;
using Microex.Swagger.Application;
using Microex.Swagger.SwaggerGen.Application;
using Microex.Swagger.SwaggerGen.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace JWTAuthServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder => 
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
            var connString = Environment.GetEnvironmentVariable("SQL_AUTH");

            if(string.IsNullOrEmpty(connString))
                connString = ((ConfigurationSection)(Configuration.GetSection("ConnectionString").GetSection("DefaultConnection"))).Value;

            // Dependency injection
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connString));                      
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IUserService, UserService>();
            services.AddMvc();



            // Swagger
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Info { Title = "JWTAuthorization Movie Cruiser", Version = "v1", Description = "JWTAuthorization Movie Cruiser" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            // Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth Server V1");
            });



            app.UseMvc();
        }
    }
}
