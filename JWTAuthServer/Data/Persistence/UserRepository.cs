using JWTAuthServer.Data.Models;
using System.Linq;

namespace JWTAuthServer.Data.Persistence
{
    public class UserRepository: IUserRepository
    {
        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context;
        }
        //Save the user information
        public User Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        //Get the login information
        public User Login(string userId, string password)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == userId && x.Password == password);
        }
        //Find the user id from User table
        public User FindUserById(string userId)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == userId);
        }

       
    }
}
