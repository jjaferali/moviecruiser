using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthServer.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GetJwtToken(string userId)
        {
            //setting the claims for user credential now
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.UniqueName, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //defining the security key and encoding the claim
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JaferAliSignature"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //defining Jwt token and essential information and setting its expiration.
            var token = new JwtSecurityToken(
                issuer: "JWTAuthServer",
                audience: "moviecruiser",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: creds
                );

            var response = new JwtSecurityTokenHandler().WriteToken(token);

            return JsonConvert.SerializeObject(response);
        }
    }
}
