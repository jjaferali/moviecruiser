using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthServer.Data.Models;
using JWTAuthServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthServer.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IUserService _service;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(IUserService service, ITokenGenerator tokenGenerator)
        {
            _service = service;
            _tokenGenerator = tokenGenerator;
        }
        
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody]User user)
        {
            try
            {
                if (_service.IsUserExists(user.UserId))
                {
                    return StatusCode(209, "User already exists.");
                }
                else
                {
                    User _user = _service.Register(user);
                    return StatusCode(201, "User Registeration successfull");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]User user)
        {
            try
            {
                var userId = user.UserId;
                var password = user.Password;

                User _user = _service.Login(userId, password);

                //calling the function for Jwt token for repective user.
                string value = _tokenGenerator.GetJwtToken(userId);

                //returning the token to consume app.
                return Ok(value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
        }
    }
}