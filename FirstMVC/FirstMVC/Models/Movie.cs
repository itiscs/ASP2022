using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Название")]
        [StringLength(50)]
        public string? Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата релиза")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Жанр")]
        [MaxLength(30)]
        public string? Genre { get; set; }
        [Display(Name = "Цена")]
        [Column("MyPrice")]
        //[Range(0,100)]
        //[RegularExpression("")]
        //[Compare("Price2")]
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
