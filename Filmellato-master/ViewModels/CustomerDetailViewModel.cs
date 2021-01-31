using Filmellato.Dtos;
using Filmellato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmellato.ViewModels
{
    public class CustomerDetailViewModel
    {
        public Customer Customer { get; set; }
        public List<IndexMovieDto> RentedMovies { get; set; }
        public List<IndexMovieDto> RecommendedMovies { get; set; }
    }
}
