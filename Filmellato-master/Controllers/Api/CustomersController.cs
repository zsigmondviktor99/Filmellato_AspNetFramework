using AutoMapper;
using System;
using System.Collections.Generic;
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
    public class CustomersController : ApiController
    {
        #region Database connection
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion

        #region Actions
        //GET: /api/customers
        //query >> opcionalis parameter, a Typeahed-tol jon a New.cshtml-bol
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        //Uj berles letrehozasanal a Customer-ek listajat ezen az API-n, ezen az action-on keresztul eri el a Typeahed, hogy a blokkolt felhasznalok ne jelenjenek meg
        [Route("api/customers/notBlockedCustomers")]
        public IHttpActionResult GetNotBlockedCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType)
                .Where(x => !x.IsBlocked);

            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
            }
            else if (customerInDb.NumberOfCurrentlyRentedMovies > 0)
            {
                return BadRequest();
            }
            else
            {
                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();
                return Ok();
            }
        }
        #endregion
    }
}
