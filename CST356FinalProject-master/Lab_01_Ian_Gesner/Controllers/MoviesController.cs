using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab_01_Ian_Gesner.Models;
using Lab_01_Ian_Gesner.Data;
using Microsoft.AspNet.Identity;

namespace Lab_01_Ian_Gesner.Controllers
{
    public class MoviesController : Controller
    {
        //private DatabaseContext db = new DatabaseContext();
        private readonly IDataRepository _dataRepository;

        public MoviesController(IDataRepository dataRepository)
        {
            //_dataRepository = new EfDataRepository();
            _dataRepository = dataRepository;
        }

        // GET: Movies
        public ActionResult Index()
        {
            //var movies = db.Movies.Include(m => m.ApplicationUser);
            //return View(movies.ToList());
            var user = User.Identity.GetUserId();
            return View(_dataRepository.GetAllMovies(user));
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _dataRepository.GetMovie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            //ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieID,Title,Director,Genre")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.Id = User.Identity.GetUserId();
                _dataRepository.AddMovie(movie);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _dataRepository.GetMovie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
           // ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email", movie.Id);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,Title,Director,Genre")] Movie movie)
        {
            movie.Id = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                _dataRepository.UpdateMovie(movie);
                return RedirectToAction("Index");
            }
            //ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email", movie.Id);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _dataRepository.GetMovie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = _dataRepository.GetMovie(id);
            _dataRepository.RemoveMovie(movie);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dataRepository.DisposeContext();
            }
            base.Dispose(disposing);
        }
    }
}
