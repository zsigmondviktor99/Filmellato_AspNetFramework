using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Filmellato.Models
{
    public class Rental
    {
        public int Id { get; set; }
        
        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }
        
        public DateTime DateRented { get; set; }
        
        //? >> nullable
        public DateTime? DateReturned { get; set; }

        [Required]
        public string UserMakeRental { get; set; }
        public string UserReturnRental { get; set; }
    }
}