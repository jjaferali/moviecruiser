using JWTAuthServer.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthServer.Data.Persistence
{
    public interface IUserRepository
    {
        User Register(User user);

        User Login(string userId, string password);

        User FindUserById(string userId);

       
    }
}
