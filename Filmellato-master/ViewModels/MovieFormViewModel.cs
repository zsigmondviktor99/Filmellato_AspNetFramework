using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Filmellato.Models;

using System.ComponentModel.DataAnnotations;

namespace Filmellato.ViewModels
{
    public class MovieFormViewModel
    {
        //IEnumerable >> nincs szuksegunk a listak nyujtotta funkcionalitasra
        public IEnumerable<Genre> Genres { get; set; }

        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 500)]
        public int LengthInMinutes { get; set; }

        [Range(1, 20)]
        [Required]
        public int? NumberInStock { get; set; }

        [Required]
        public int? GenreId { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        public string ImagePath { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Film adatainak módosítása" : "Film hozzáadása";
            }
        }

        //NEW >> nem kaptunk filmet, letrehozzuk
        public MovieFormViewModel() 
        {
            //A form rejtett ID es Bemutatasi datum mezojenek adunk alaperteket
            Id = 0;
            ReleaseDate = DateTime.Parse("1900-01-01");
        }

        //EDIT >> kaptunk filmet, modositunk
        public MovieFormViewModel(Movie movie)
        {
            //A kapott film adataival toltjuk ki a formot
            Id = movie.Id;
            Name = movie.Name;
            Director = movie.Director;
            ReleaseDate = movie.ReleaseDate;
            LengthInMinutes = movie.LengthInMinutes;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
            ShortDescription = movie.ShortDescription;
        }
    }
}
