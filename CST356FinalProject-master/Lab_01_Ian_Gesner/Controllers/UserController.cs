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
using SimpleInjector;

namespace Lab_01_Ian_Gesner.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IDataRepository _dataRepository;

        public UserController(IDataRepository dataRepository)
        {
            //_dataRepository = new EfDataRepository();
            _dataRepository = dataRepository;
            
        }

        // GET: User
        public ActionResult Index()
        {
            return View(_dataRepository.GetAllUsers());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //User user = db.Users.Find(id);
            User user = _dataRepository.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        [HttpGet]
        public ActionResult Create()
        {
            var groups = _dataRepository.GetAllGroups();
            ViewBag.GroupList = new MultiSelectList(groups, "GroupID", "Name"); // by including name, you need to let Entity know about Name column - see notes

            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,FirstName,LastName,EmailAddress")] User user, List<int> groupIDs)
        {
            if (ModelState.IsValid)
            {
                user.Group = new List<Group>();
                if (groupIDs != null)
                {
                    foreach (var groupId in groupIDs)
                    {
                        user.Group.Add(new Group
                        {
                            GroupID = groupId
                        });
                    }
                }

                _dataRepository.AddUser(user);

                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //User user = db.Users.Find(id);
            User user = _dataRepository.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,FirstName,LastName,EmailAddress")] User user)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.UpdateUser(user);
                //TODO: Test edit
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //User user = db.Users.Find(id);
            User user = _dataRepository.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
 
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //User user = db.Users.Find(id);
            //db.Users.Remove(user);
            //db.SaveChanges();

            User user = _dataRepository.GetUser(id);
            _dataRepository.RemoveUser(user);

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
