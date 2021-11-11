using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVCCodeFirstVidly.Models;
using MVCCodeFirstVidly.ViewModels;
using System.Data.Entity.Validation;

namespace MVCCodeFirstVidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext  _context;
            public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            List<Movie> movies = _context.Movies.Include(g=>g.Genre).ToList();
            if (movies == null)
                return HttpNotFound();
            return View(movies);
        }
        public ActionResult Details(int id)
        {
            Movie movie = _context.Movies.Include(g=>g.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        public ActionResult New()
        {
            var genres = _context.Genres;
            var newMovieModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm", newMovieModel);
        }

        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                //movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
                try
                {
                    _context.SaveChanges();
                }
                catch(DbEntityValidationException e)
                {
                    Console.WriteLine(e);
                }
            }
                
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;                
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
               
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

    }
}