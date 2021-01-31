using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Filmellato.Models;

namespace Filmellato.Dtos
{
    public class IndexMovieDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string GenreName { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
