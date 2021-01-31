using Filmellato.Models;
using Filmellato.ViewModels;
using Filmellato.Dtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Filmellato.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        #region Database connection
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        #endregion

        #region Actions
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(x => x.Genre).OrderByDescending(x => x.ReleaseDate).ToList();
            IndexMoviesViewModel viewModel = new IndexMoviesViewModel();

            if (movies.Count > 0)
            {
                List<IndexMovieDto> _movieDtos = new List<IndexMovieDto>();

                foreach (Movie m in movies)
                {
                    _movieDtos.Add(new IndexMovieDto { Id = m.Id, Url = "/movies/details/" + m.Id, ImagePath = m.ImagePath, Name = m.Name, GenreName = m.Genre.GenreName, ReleaseDate = m.ReleaseDate });
                }

                viewModel.movies = _movieDtos;

                List<IndexMovieDto> _romanticFour = _movieDtos.FindAll(x => x.GenreName.Equals("Romantikus")).OrderByDescending(x => x.ReleaseDate).ToList();
                List<IndexMovieDto> _horrorFour = _movieDtos.FindAll(x => x.GenreName.Equals("Horror")).OrderByDescending(x => x.ReleaseDate).ToList();
                List<IndexMovieDto> _familyFour = _movieDtos.FindAll(x => x.GenreName.Equals("Családi")).OrderByDescending(x => x.ReleaseDate).ToList();
                List<IndexMovieDto> _funnyFour = _movieDtos.FindAll(x => x.GenreName.Equals("Vígjáték")).OrderByDescending(x => x.ReleaseDate).ToList();

                const int pageDb = 8;

                if (_movieDtos.Count >= pageDb)
                {
                    viewModel.freshestFour = new List<IndexMovieDto>();

                    for (int i = 0; i <= pageDb - 1; i++)
                    {
                        viewModel.freshestFour.Add(_movieDtos[i]);
                    }
                }

                if (_romanticFour.Count >= pageDb)
                {
                    viewModel.romanticFour = new List<IndexMovieDto>();

                    for (int i = 0; i <= pageDb - 1; i++)
                    {
                        viewModel.romanticFour.Add(_romanticFour[i]);
                    }
                }

                if (_horrorFour.Count >= pageDb)
                {
                    viewModel.horrorFour = new List<IndexMovieDto>();

                    for (int i = 0; i <= pageDb - 1; i++)
                    {
                        viewModel.horrorFour.Add(_horrorFour[i]);
                    }
                }

                if (_familyFour.Count >= pageDb)
                {
                    viewModel.familyFour = new List<IndexMovieDto>();

                    for (int i = 0; i <= pageDb - 1; i++)
                    {
                        viewModel.familyFour.Add(_familyFour[i]);
                    }
                }

                if (_funnyFour.Count >= pageDb)
                {
                    viewModel.funnyFour = new List<IndexMovieDto>();

                    for (int i = 0; i <= pageDb - 1; i++)
                    {
                        viewModel.funnyFour.Add(_funnyFour[i]);
                    }
                }
            }

            return View("Index", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion
    }
}
