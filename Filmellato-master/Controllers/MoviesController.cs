using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Infrastructure.MappingViews;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

using Filmellato.Models;
using Filmellato.ViewModels;

namespace Filmellato.Controllers
{
    public class MoviesController : Controller
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
        //URL: /movies
        public ViewResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole(RoleName.CanManageMovies))
                {
                    return View("List");
                }
                else
                {
                    return View("ReadOnlyList");
                }
            }
            else
            {
                return View("NonAuthanticatedList");
            }
        }

        //URL: /movies/details/{id]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        //URL: /movies/edit/1
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        //URL: /movies/new
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {

                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie, HttpPostedFileBase ImagePath)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.NumberAvailable = movie.NumberInStock;

                if (ImagePath != null && ImagePath.ContentLength > 0)
                {
                    movie.ImagePath = SaveImage(ImagePath);
                }
                else
                {
                    movie.ImagePath = "/Content/Images/Movies/_nodocument.png";
                }

                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.Director = movie.Director;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.LengthInMinutes = movie.LengthInMinutes;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ShortDescription = movie.ShortDescription;

                //Amennyiben van kiberelve a filmbol, de modositjuk a raktaron levo mennyiseget, akkor is le kell vonnunk az elerheto darabszambol a kintlevoket
                movieInDb.NumberAvailable += movie.NumberInStock - movieInDb.NumberInStock;
                movieInDb.NumberInStock = movie.NumberInStock;

                if (ImagePath != null && ImagePath.ContentLength > 0)
                {
                    movieInDb.ImagePath = SaveImage(ImagePath);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public string SaveImage(HttpPostedFileBase ImagePath)
        {
            string directory = Server.MapPath("~/Content/Images/Movies/");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string fileName = Path.GetFileName(ImagePath.FileName);
            string fullPath = Path.Combine(directory, fileName);
            ImagePath.SaveAs(fullPath);
            return Path.Combine("/Content/Images/Movies/", fileName);
        }
        #endregion
    }
}
