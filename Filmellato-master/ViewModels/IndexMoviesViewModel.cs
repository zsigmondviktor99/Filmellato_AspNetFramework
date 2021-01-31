using Filmellato.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmellato.ViewModels
{
    public class IndexMoviesViewModel
    {
        public List<IndexMovieDto> movies;
        public List<IndexMovieDto> freshestFour;
        public List<IndexMovieDto> romanticFour;
        public List<IndexMovieDto> horrorFour;
        public List<IndexMovieDto> familyFour;
        public List<IndexMovieDto> funnyFour;
    }
}
