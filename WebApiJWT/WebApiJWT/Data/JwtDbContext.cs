using Microsoft.EntityFrameworkCore;
using WebApiJWT.Models;

namespace WebApiJWT.Data
{
    public class JwtDbContext:DbContext
    {

        public JwtDbContext(DbContextOptions<JwtDbContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
