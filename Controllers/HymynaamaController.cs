using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hyvinvointisovellus;

namespace Hyvinvointisovellus.Controllers
{
    public class HymynaamaController : Controller
    {
        private HyvinvointiDBEntities1 db = new HyvinvointiDBEntities1();

        // GET: Hymynaama
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Kirjautuminen", "Home");
            }
            else
            {
                var hymynaama = db.Hymynaama.Include(h => h.Tyontekijat);
                return View(hymynaama.ToList());
            }
            
        }

        // GET: Hymynaama/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hymynaama hymynaama = db.Hymynaama.Find(id);
            if (hymynaama == null)
            {
                return HttpNotFound();
            }
            return View(hymynaama);
        }

        // GET: Hymynaama/Create
        public ActionResult Create()
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            ViewBag.TyontekijaID = new SelectList(db.Tyontekijat, "TyontekijaID", "Sukunimi", "Start");
            return View();
        }

        // POST: Hymynaama/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HymynaamaID,TyontekijaID,Hymynaama1,Start")] Hymynaama hymynaama)
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            if (ModelState.IsValid)
            {
                db.Hymynaama.Add(hymynaama);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TyontekijaID = new SelectList(db.Tyontekijat, "TyontekijaID", "Sukunimi", hymynaama.TyontekijaID);
            return View(hymynaama);
        }

        // GET: Hymynaama/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hymynaama hymynaama = db.Hymynaama.Find(id);
            if (hymynaama == null)
            {
                return HttpNotFound();
            }
            ViewBag.TyontekijaID = new SelectList(db.Tyontekijat, "TyontekijaID", "Sukunimi", hymynaama.TyontekijaID);
            return View(hymynaama);
        }

        // POST: Hymynaama/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HymynaamaID,TyontekijaID,Hymynaama1")] Hymynaama hymynaama)
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            if (ModelState.IsValid)
            {
                db.Entry(hymynaama).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TyontekijaID = new SelectList(db.Tyontekijat, "TyontekijaID", "Sukunimi", hymynaama.TyontekijaID);
            return View(hymynaama);
        }

        // GET: Hymynaama/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hymynaama hymynaama = db.Hymynaama.Find(id);
            if (hymynaama == null)
            {
                return HttpNotFound();
            }
            return View(hymynaama);
        }

        // POST: Hymynaama/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            Hymynaama hymynaama = db.Hymynaama.Find(id);
            db.Hymynaama.Remove(hymynaama);
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

        public JsonResult GetEvents()
        {
            using (HyvinvointiDBEntities1 db = new HyvinvointiDBEntities1())
            {
                var events = db.Hymynaama.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}

