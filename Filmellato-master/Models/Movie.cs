using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Filmellato.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kérem adja meg a film címét!")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kérem adja meg a film rendezõjét!")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Kérem adja meg a film bemutatásának dátumát!")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Kérem adja meg a film hosszát percben!")]
        [Range(1, 500, ErrorMessage = "A film hossza percben 1 és 500 között kell legyen!")]
        public int LengthInMinutes { get; set; }

        [Required(ErrorMessage = "Kérem adja meg hány darab érhetõ el a filmbõl!")]
        [Range(1, 20, ErrorMessage = "A darabszámnak 1 és 20 között kell lennie!")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        //Navigacios tulajdonsag >> atnavigal minket a masik tipusra (Film >> Film tipusa)
        public Genre Genre { get; set; }

        //Entity ez alapjan kesziti el az idegen kulcsot
        [Required(ErrorMessage = "Kérem adja meg a film típusát!")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Kérem adja meg a film rövid leírását!")]
        public string ShortDescription { get; set; }

        public string ImagePath { get; set; }


        public Movie()
        {
            DateAdded = DateTime.Now;
        }
    }
}
