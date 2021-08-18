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
    public class PalauteController : Controller
    {
        private HyvinvointiDBEntities1 db = new HyvinvointiDBEntities1();

        // GET: Palaute
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
                var palaute = db.Palaute.Include(p => p.Tyontekijat);
                return View(palaute.ToList());
            }

            //tämä esiin kun kirjautuminen halutaan käyttöön ->

            //if (Session["Käyttäjätunnus"] == null)
            //{
            //    return RedirectToAction("Kirjautuminen", "Home");
            //}
            //else
            //{
            //    ViewBag.Loggedstatus = "Olet kirjautunut sisään ";
            //    return View(palaute.ToList());
            //}
        }

        // GET: Palaute/Details/5
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
            Palaute palaute = db.Palaute.Find(id);
            if (palaute == null)
            {
                return HttpNotFound();
            }
            return View(palaute);
        }

        // GET: Palaute/Create
        public ActionResult Create()
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            ViewBag.TyontekijaID = new SelectList(db.Tyontekijat, "TyontekijaID", "Etunimi");
            return View();
        }

        // POST: Palaute/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PalauteID,TyontekijaID,Palaute1")] Palaute palaute)
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            if (ModelState.IsValid)
            {
                db.Palaute.Add(palaute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TyontekijaID = new SelectList(db.Tyontekijat, "TyontekijaID", "Etunimi", palaute.TyontekijaID);
            return View(palaute);
        }

        // GET: Palaute/Edit/5


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
            Palaute palaute = db.Palaute.Find(id);
            if (palaute == null)
            {
                return HttpNotFound();
            }
            ViewBag.TyontekijaID = new SelectList(db.Tyontekijat, "TyontekijaID", "Etunimi", palaute.TyontekijaID);
            return View(palaute);
        }

        // POST: Palaute/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PalauteID,TyontekijaID,Palaute1")] Palaute palaute)
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            if (ModelState.IsValid)
            {
                db.Entry(palaute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TyontekijaID = new SelectList(db.Tyontekijat, "TyontekijaID", "Etunimi", palaute.TyontekijaID);
            return View(palaute);
        }

        // GET: Palaute/Delete/5
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
            Palaute palaute = db.Palaute.Find(id);
            if (palaute == null)
            {
                return HttpNotFound();
            }
            return View(palaute);
        }

        // POST: Palaute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            Palaute palaute = db.Palaute.Find(id);
            db.Palaute.Remove(palaute);
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
