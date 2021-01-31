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
        /* No List, IEnumerable >> we do not need any functionality
        provided by the List class (add / remove / access an object by index),
        all we need is a way to iterate over the Genres
        
        If later we will replace List with another collection (like Array),
        we do not have to come back here to modify this ViewModel as long
        as that collection implement IEnumerable*/
        public IEnumerable<Genre> Genres { get; set; }

        /*Movie, or copy and paste their propertyes >>
        now we will use the Movie entity, because we want to
        use them later, and we do not need new properties,
        but in case we need new properties required by the view, we should
        separate the domain and view models*/

        //public Movie Movie { get; set; }

        //We do not use the Movie class, we put here the necessary properties
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

        //NEW
        public string ImagePath { get; set; }

        //Set the title on the MovieForm view
        public string Title
        {
            get
            {
                return Id != 0 ? "Film adatainak módosítása" : "Film hozzáadása";
            }
        }

        //Constructors
        //NEW >> we do not get a movie, we create it
        public MovieFormViewModel() 
        {
            //Make sure that in our form the Id hidden field is populated
            Id = 0;
            ReleaseDate = DateTime.Parse("1900-01-01");
        }

        //EDIT >> The movie argument is given by MoviesController Edit action
        public MovieFormViewModel(Movie movie)
        {
            //We set the properties here with the properties of the given movie object by Edit action from MoviesController
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
