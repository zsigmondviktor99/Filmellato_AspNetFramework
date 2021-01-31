using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Filmellato.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 500)]
        public int LengthInMinutes { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        //NEW
        public string ImagePath { get; set; }
    }
}