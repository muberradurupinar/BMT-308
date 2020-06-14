using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDiyethane.Models.Entity;
using System.Web.Security;
namespace MVCDiyethane.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        DB_DIYETEntities db = new DB_DIYETEntities();

        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLUYELER u,TBLPERSONEL p)
        {
            var bilgiler = db.TBLUYELER.FirstOrDefault(x => x.MAIL == u.MAIL && x.SIFRE == u.SIFRE);
            var degerler = db.TBLPERSONEL.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
           
           if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                return RedirectToAction("Index","Vitrin");
            }
           else if(degerler != null)
            {
                FormsAuthentication.SetAuthCookie(degerler.MAIL, false);
                return RedirectToAction("Index", "Diyetler");
            }
           else{
                return View();

            }
        }
    }
}