using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVCCodeFirstVidly.Models;

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

        
        
    }
}