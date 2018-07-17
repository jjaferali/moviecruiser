using JWTAuthServer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthServer.Data.Persistence
{
    public interface IUserContext
    {
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
