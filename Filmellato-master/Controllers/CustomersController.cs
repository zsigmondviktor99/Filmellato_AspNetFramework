using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

using Filmellato.Models;
using Filmellato.ViewModels;
using System.Runtime.Caching;
using System.IO;
using Filmellato.Dtos;

namespace Filmellato.Controllers
{
    [Authorize]
    public class CustomersController : Controller
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
        //URL:  /customers
        public ActionResult Index()
        {

            return View();
        }

        //URL:  /customers/details/{id}
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            //Azok a kiberelt filmek, amiket meg nem hozott vissza
            List<Movie> rentedMovies = _context.Rentals
                .Include(r => r.Customer.MembershipType)
                .Include(r => r.Movie.Genre)
                .ToList()
                .FindAll(r => r.Customer.Id == customer.Id && r.DateReturned == null)
                .Select(r => r.Movie)
                .OrderBy(m => m.Name)
                .ToList();

            List<IndexMovieDto> rentedMovieDtos = new List<IndexMovieDto>();

            if (rentedMovies.Count > 0)
            {
                foreach (Movie m in rentedMovies)
                {
                    rentedMovieDtos.Add(new IndexMovieDto { Id = m.Id, Url = "/movies/details/" + m.Id, ImagePath = m.ImagePath, Name = m.Name, GenreName = m.Genre.GenreName, ReleaseDate = m.ReleaseDate });
                }
            }

            //Az eddigi osszes berlesenek a GenreId-jai, mindegyik csak 1x szerepel
            List<int> rentalIdHistory = _context.Rentals
                .Include(r => r.Customer.MembershipType)
                .Include(r => r.Movie.Genre)
                .ToList()
                .FindAll(r => r.Customer.Id == customer.Id)
                .Select(r => r.Movie.GenreId)
                .ToHashSet()
                .ToList();

            List<IndexMovieDto> recommendedMovieDtos = new List<IndexMovieDto>();

            if (rentalIdHistory.Count > 0 && !customer.IsBlocked)
            {
                for (int i = 0; i <= rentalIdHistory.Count - 1; i++)
                {
                    try
                    {
                        Movie mo = _context.Movies.Include(m => m.Genre).ToList().OrderByDescending(m => m.ReleaseDate).First(m => m.GenreId == rentalIdHistory[i] && !rentedMovies.Contains(m));
                        recommendedMovieDtos.Add(new IndexMovieDto { Id = mo.Id, Url = "/movies/details/" + mo.Id, ImagePath = mo.ImagePath, Name = mo.Name, GenreName = mo.Genre.GenreName, ReleaseDate = mo.ReleaseDate });
                    }
                    catch (Exception)
                    {

                    }
                }
            }


            CustomerDetailViewModel viewModel = new CustomerDetailViewModel
            {
                Customer = customer,
                RentedMovies = rentedMovieDtos,
                RecommendedMovies = recommendedMovieDtos
            };

            return View(viewModel);
        }

        //URL: /customers/edit/{id}
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        //URL: /customers/new
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer, HttpPostedFileBase ImagePath)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                if (ImagePath != null && ImagePath.ContentLength > 0)
                {
                    customer.ImagePath = SaveImage(ImagePath);
                }
                else
                {
                    customer.ImagePath = "/Content/Images/Customers/_nodocument.png";
                }

                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.IsBlocked = customer.IsBlocked;
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.Email = customer.Email;
                customerInDb.PhoneNumber = customer.PhoneNumber;
                customerInDb.Address = customer.Address;
                customerInDb.IdentityCard = customer.IdentityCard;

                if (ImagePath != null && ImagePath.ContentLength > 0)
                {
                    customerInDb.ImagePath = SaveImage(ImagePath);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public string SaveImage(HttpPostedFileBase ImagePath)
        {
            string directory = Server.MapPath("~/Content/Images/Customers/");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string fileName = Path.GetFileName(ImagePath.FileName);
            string fullPath = Path.Combine(directory, fileName);
            ImagePath.SaveAs(fullPath);
            return Path.Combine("/Content/Images/Customers/", fileName);
        }
        #endregion
    }
}
