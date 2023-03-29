using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace AdrianWoronaProject91511.Models
{
    public class Film
    {
        //Sposób 1
        public int Id { get; set; }

        [Required (ErrorMessage ="Add title")]
        public string Title { get; set; } //Required sprawia, że wartość jest wymagana

        public string Director { get; set; }

        [StringLength (500)]
        public string Desc { get; set; }

        public decimal? Price { get; set; } //Wartość nieobowiązkowa

        public DateTime PublishDate { get; set; }

        public string PosterName { get; set; }

        //[ForeignKey("Category")] Używamy kiedy chcemy mieć inną nazwę klucza obcego
        public int CategoryId { get; set; }

        public Category Category { get; set;}

        //Sposób 2
        //public int FilmId { get; set; }

        //Sposób 3
        //[Key]
        //public int IdFilm { get; set; }
    }
}
