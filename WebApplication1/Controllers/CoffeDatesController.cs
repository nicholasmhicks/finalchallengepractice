using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Controllers
{
    public class CoffeDatesController : Controller
    {
        private coffeedbEntities db = new coffeedbEntities();


        public ActionResult MembersAmmount(string email)
        {
            List<CoffeDate> coffeDate = db.CoffeDates.Where(x => x.ShoutId == email).ToList();
            if (coffeDate == null)
            {
                return HttpNotFound();
            }
            return View(coffeDate);
        }
        // GET: CoffeDates
        [Authorize]
        public ActionResult Index()
        {
            //get user credentials of logged in user
            var manage = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //create object of information
            var currentUser = manage.FindById(User.Identity.GetUserId());
            //pass object to the view bag to use in view
            ViewBag.Confirmed = currentUser.EmailConfirmed;
            return View(db.CoffeDates.ToList());
        }

        [Authorize]
        public ActionResult Passed()
        {
            return View(db.CoffeDates.ToList());
        }

        [Authorize]
        public ActionResult PassedMoreDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeDate coffeDate = db.CoffeDates.Find(id);
            if (coffeDate == null)
            {
                return HttpNotFound();
            }
            return View(coffeDate);
        }
        // GET: CoffeDates/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeDate coffeDate = db.CoffeDates.Find(id);
            if (coffeDate == null)
            {
                return HttpNotFound();
            }
            return View(coffeDate);
        }

        // GET: CoffeDates/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoffeDates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Time,Passed,ShoutId,ShoutPrice,Venue")] CoffeDate coffeDate)
        {
            if (ModelState.IsValid)
            {
                db.CoffeDates.Add(coffeDate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coffeDate);
        }

        // GET: CoffeDates/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeDate coffeDate = db.CoffeDates.Find(id);
            if (coffeDate == null)
            {
                return HttpNotFound();
            }
            return View(coffeDate);
        }

        // POST: CoffeDates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Time,Passed,ShoutId,ShoutPrice")] CoffeDate coffeDate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffeDate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coffeDate);
        }

        // GET: CoffeDates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeDate coffeDate = db.CoffeDates.Find(id);
            if (coffeDate == null)
            {
                return HttpNotFound();
            }
            return View(coffeDate);
        }

        // POST: CoffeDates/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoffeDate coffeDate = db.CoffeDates.Find(id);
            db.CoffeDates.Remove(coffeDate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
