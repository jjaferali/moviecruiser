using JWTAuthServer.Data.Models;

namespace JWTAuthServer.Services
{
    public interface IUserService
    {
        bool IsUserExists(string userId);

        User Login(string userId, string password);

        User Register(User user);

       
    }
}
