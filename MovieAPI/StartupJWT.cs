using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace MovieCruiser
{
    public partial class Startup
    {
        public void ConfigureJwtAuthService(IConfiguration configuration, IServiceCollection services)
        {
            var audience = Configuration.GetSection("Audience");
            var symmetrickey = audience["Secret"];
            var byteArray = Encoding.ASCII.GetBytes(symmetrickey);
            var signingkey = new SymmetricSecurityKey(byteArray);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingkey,
                ValidateIssuer = true,
                ValidIssuer = audience["Issuer"],
                ValidateAudience = true,
                ValidAudience = audience["Audience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => o.TokenValidationParameters = tokenValidationParameters);
        }
    }
}
