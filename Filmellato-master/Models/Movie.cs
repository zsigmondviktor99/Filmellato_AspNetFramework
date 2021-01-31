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

        [Required(ErrorMessage = "Please enter the movie's title.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the movie's director.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Please enter the movie's release date.")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Please enter the movie's length in minutes.")]
        [Range(1, 500, ErrorMessage = "The field 'Length in Minutes' must be between 1 and 500.")]
        public int LengthInMinutes { get; set; }

        [Required(ErrorMessage = "Please fill up the 'Number in Stuck' field.")]
        [Range(1, 20, ErrorMessage = "The field 'Number in Stock' must be between 1 and 20.")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        //Navigation property >> navigate us to a new type
        //Movie >> to its Genre
        public Genre Genre { get; set; }

        //Entity recognise this as a foreign key
        [Required(ErrorMessage = "Please select the movie's genre.")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Please fill up the 'Short Description' field.")]
        public string ShortDescription { get; set; }

        //NEW
        public string ImagePath { get; set; }


        //Constructor >> to fix "The conversion of a datetime2 data type to a datetime data type resulted in an out-of-range value" error
        public Movie()
        {
            DateAdded = DateTime.Now;
        }
    }

    //Picking a radnom movie >> URL: /movies/random >> Movies controller Random action
}
