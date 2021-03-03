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

        [Required(ErrorMessage = "K�rem adja meg a film c�m�t!")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "K�rem adja meg a film rendez�j�t!")]
        public string Director { get; set; }

        [Required(ErrorMessage = "K�rem adja meg a film bemutat�s�nak d�tum�t!")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "K�rem adja meg a film hossz�t percben!")]
        [Range(1, 500, ErrorMessage = "A film hossza percben 1 �s 500 k�z�tt kell legyen!")]
        public int LengthInMinutes { get; set; }

        [Required(ErrorMessage = "K�rem adja meg h�ny darab �rhet� el a filmb�l!")]
        [Range(1, 20, ErrorMessage = "A darabsz�mnak 1 �s 20 k�z�tt kell lennie!")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        //Navigacios tulajdonsag >> atnavigal minket a masik tipusra (Film >> Film tipusa)
        public Genre Genre { get; set; }

        //Entity ez alapjan kesziti el az idegen kulcsot
        [Required(ErrorMessage = "K�rem adja meg a film t�pus�t!")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "K�rem adja meg a film r�vid le�r�s�t!")]
        public string ShortDescription { get; set; }

        public string ImagePath { get; set; }


        public Movie()
        {
            DateAdded = DateTime.Now;
        }
    }
}
