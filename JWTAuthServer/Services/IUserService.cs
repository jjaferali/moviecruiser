using JWTAuthServer.Data.Models;
using System.Collections.Generic;

namespace JWTAuthServer.Services
{
    public interface IUserService
    {
        bool IsUserExists(string userId);

        User Login(string userId, string password);

        User Register(User user);

       
    }
}
