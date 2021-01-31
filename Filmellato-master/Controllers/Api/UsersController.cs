using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Filmellato.Models;

namespace Filmellato.Controllers.Api
{
    public class UsersController : ApiController
    {
        #region Database connection
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion

        #region Actions
        // /api/users
        public IHttpActionResult GetUsers()
        {
            var usersQuery = _context.Users.ToList();

            return Ok(usersQuery);
        }

        // DELETE: /api/users/1
        [System.Web.Http.HttpDelete]
        public void DeleteUser(string id)
        {
            var userInDb = _context.Users.SingleOrDefault(u => u.Id == id);

            if (userInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Users.Remove(userInDb);
                _context.SaveChanges();
            }
        }
        #endregion
    }
}
