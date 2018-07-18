using JWTAuthServer.Data.Models;
using JWTAuthServer.Data.Persistence;

namespace JWTAuthServer.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

       //Checking the user exist or not and return value boolean
        public bool IsUserExists(string userId)
        {
            var _user = _repo.FindUserById(userId);

            return _user != null ? true : false;
        }
        //Validating login credential 
        public User Login(string userId, string password)
        {
            var user = _repo.Login(userId, password);
            return user != null ? user: throw new System.Exception("Invalid UserId or password.");
        }
        //Register the user
        public User Register(User user)
        {
            return _repo.Register(user);
        }
    }
}
