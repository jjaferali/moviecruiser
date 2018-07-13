using JWTAuthServer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthServer.Data.Persistence
{
    public class UserRepository: IUserRepository
    {
        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context;
        }

        public User Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Login(string userId, string password)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == userId && x.Password == password);
        }

        public User FindUserById(string userId)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == userId);
        }

       
    }
}
