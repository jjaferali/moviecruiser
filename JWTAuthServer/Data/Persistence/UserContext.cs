using JWTAuthServer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthServer.Data.Persistence
{
    public class UserContext : DbContext, IUserContext
    {
        public UserContext(DbContextOptions<UserContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
