using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hyvinvointisovellus;
using System.Data.Entity;
using System.Net;

namespace Hyvinvointisovellus.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
                return View("Kirjautuminen");
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            return View();
            throw new NotImplementedException();
        }
        public ActionResult IndexTyonantaja()
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
                return View("Kirjautuminen");
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            return View();
            throw new NotImplementedException();
        }
        public ActionResult IndexTyontekija()
        {

            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
                return View("Kirjautuminen");
            }
            else ViewBag.LoggedStatus = "Kirjautunut";

            return View();
            throw new NotImplementedException();

        }

        public ActionResult About()
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Kirjautuminen()
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Ei kirjautunut";
            }
            else ViewBag.LoggedStatus = "Kirjautunut";
            return View();
        }
        
        private HyvinvointiDBEntities1 db = new HyvinvointiDBEntities1();

        public ActionResult OmattiedotTyontekija()
        {
            var hymynaama = db.Hymynaama.Include(h => h.Tyontekijat);
            return View(hymynaama.ToList());
            throw new NotImplementedException();
        }        
        public ActionResult OmattiedotTyonantaja()
        {
            return View();
            throw new NotImplementedException();
        }


        [HttpPost]
        public ActionResult Authorize(Kirjautuminen LoginModel)
        {
            HyvinvointiDBEntities1 db = new HyvinvointiDBEntities1();
            //Haetaan käyttäjän/Loginin tiedot annetuilla tunnustiedoilla tietokannasta LINQ -kyselyllä
            var LoggedUser = db.Kirjautuminen.SingleOrDefault(x => x.Kayttajatunnus == LoginModel.Kayttajatunnus && x.Salasana == LoginModel.Salasana);
            if (LoggedUser != null)
            {
                //ViewBag.LoginMessage = "Kirjautuminen onnistui!";
                ViewBag.LoggedStatus = "Kirjautunut";
                Session["UserName"] = LoggedUser.Kayttajatunnus;
                if (LoggedUser.Kayttajatunnus == "Tiina")
				{
                    Session["Admin"] = LoggedUser.Kayttajatunnus;
                    return RedirectToAction("IndexTyonantaja", "Home");
                }
                else 
                { 
                return RedirectToAction("IndexTyontekija", "Home"); //Tässä määritellään mihin onnistunut kirjautuminen johtaa --> Home/Index
                }
            }
            else
            {
                //ViewBag.LoginMessage = "Kirjautuminen epäonnistui!";
                ViewBag.LoggedStatus = "Ei kirjautunut";
                LoginModel.LoginErrorMessage = "Tuntematon käyttäjätunnus tai salasana. Yritä uudelleen!";
                return View("Kirjautuminen", LoginModel); 
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            ViewBag.LoggedStatus = "Ei kirjautunut";
            return RedirectToAction("Index", "Home"); //Uloskirjautumisen jälkeen pääsivulle
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