using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Filmellato.Dtos;
using Filmellato.Models;
using AutoMapper;
using System.Data.Entity;

namespace Filmellato.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        #region Database connection
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion

        #region Actions
        //GET: /rentals
        public IHttpActionResult GetRentals()
        {
            var rentals = _context.Rentals.Include(r => r.Customer).Include(r => r.Movie).ToList();
            return Ok(rentals);
        }

        //PUT: /api/newRentals/1
        [HttpPut]
        public IHttpActionResult UpdateRental(int id, NewRentalDto rental)
        {
            var rentalInDb = _context.Rentals.Include(r => r.Movie).Include(r => r.Customer).SingleOrDefault(r => r.Id == id);
            var customerWhoRent = _context.Customers.SingleOrDefault(c => c.Id == rentalInDb.Customer.Id);

            if (rentalInDb.DateReturned == null)
            {
                rentalInDb.DateReturned = DateTime.Now;
                rentalInDb.Movie.NumberAvailable++;
                rentalInDb.UserReturnRental = User.Identity.Name;

                customerWhoRent.NumberOfCurrentlyRentedMovies--;

                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("Ezt a filmet már visszahozták.");
            }
        }
        
        //POST: /api/newRentals/new
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
            {
                return BadRequest("Nincs egy MovieId sem megadva.");
            }

            if (newRental.MovieIds.Count > 5)
            {
                return BadRequest("Nem adhatsz ki 5-nél több filmet egyszerre.");
            }

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
            {
                return BadRequest("CustomerId nem létezik.");
            }

            if (customer.IsBlocked == true)
            {
                return BadRequest("Az ügyfél blokkolva van.");
            }

            if (customer.NumberOfCurrentlyRentedMovies + newRental.MovieIds.Count > 5)
            {
                return BadRequest("Ennek az ügyfélnek már van 5 kibérelt filme.");
            }

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
            {
                return BadRequest("Egy vagy több MovieId nem létezik.");
            }

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("A film nem elérhető.");
                }

                movie.NumberAvailable--;
                customer.NumberOfCurrentlyRentedMovies++;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now,
                    UserMakeRental = User.Identity.Name
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
        #endregion
    }
}
