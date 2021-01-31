using AutoMapper;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Filmellato.Dtos;
using Filmellato.Models;
using System.Data.Entity;

namespace Filmellato.Controllers.Api
{
    public class MoviesController : ApiController
    {
        #region Database connection
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion

        #region Actions
        //GET: /api/movies
        //query >> opcionalis parameter, a Typeahed-tol jon a New.cshtml-bol
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }

            var movieDtos = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }
            else if (movieInDb.NumberAvailable != movieInDb.NumberInStock)
            {
                return BadRequest();
            }
            else
            {
                _context.Movies.Remove(movieInDb);
                _context.SaveChanges();
                return Ok();
            }
        }
        #endregion
    }
}
