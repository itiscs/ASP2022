using Microsoft.EntityFrameworkCore;

namespace FirstMVC.Models
{
    public class MoviesDb : DbContext
    {
        public MoviesDb(DbContextOptions<MoviesDb> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

    }
}
