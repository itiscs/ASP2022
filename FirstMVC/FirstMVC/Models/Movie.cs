using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FirstMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }

    public class MoviesDb : DbContext
    {
        public MoviesDb(DbContextOptions<MoviesDb> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }



}
