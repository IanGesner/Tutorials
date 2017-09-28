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
using Lab_01_Ian_Gesner.Services;
using Microsoft.AspNet.Identity;

namespace Lab_01_Ian_Gesner.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        //private DataContext db = new DataContext();
        //private EfDataRepository _dataRepository;
        private readonly IDataRepository _dataRepository;
        private readonly IGroupService _groupService;

        public GroupController(IDataRepository dataRepository, IGroupService groupService)
        {
            //_dataRepository = new EfDataRepository();
            _dataRepository = dataRepository;
            _groupService = groupService;
        }


        // GET: Groups
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            return View(_dataRepository.GetAllGroups(user));
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Group group = db.Groups.Find(id);
            Group group = _dataRepository.GetGroup(id);
            if (group == null)
            {
                return HttpNotFound();
            }

            if (_groupService.HasEscalatedPrivileges(group))
                ViewBag.HasEscalatedPrivileges = "True";
            else
                ViewBag.HasEscalatedPrivileges = "False";

            return View(group);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,Name")] Group group)
        {
            if (ModelState.IsValid)
            {
                //db.Groups.Add(group);
                //db.SaveChanges();
                group.Id = User.Identity.GetUserId();
                _dataRepository.AddGroup(group);
                return RedirectToAction("Index");
            }

            return View(group);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Group group = db.Groups.Find(id);
            Group group = _dataRepository.GetGroup(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,Name")] Group group)
        {
            group.Id = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                _dataRepository.UpdateGroup(group);
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Group group = db.Groups.Find(id);
            Group group = _dataRepository.GetGroup(id);
            if (group == null)
            {
                return HttpNotFound();
            }

            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Group group = db.Groups.Find(id);
            //db.Groups.Remove(group);
            //db.SaveChanges();
            Group group = _dataRepository.GetGroup(id);
            _dataRepository.RemoveGroup(group);

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
