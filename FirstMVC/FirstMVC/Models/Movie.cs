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
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата релиза")]
        public DateTime ReleaseDate { get; set; }

        public int GenreId { get; set; }
        [Display(Name = "Жанр")]
        public Genre? Genre { get; set; }
        [Display(Name = "Цена")]
        [Column("MyPrice")]
        //[Range(0,100)]
        //[RegularExpression("")]
        //[Compare("Price2")]
        public decimal Price { get; set; }
    }

   



}
