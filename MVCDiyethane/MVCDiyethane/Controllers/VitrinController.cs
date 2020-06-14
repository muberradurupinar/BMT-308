using MVCDiyethane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDiyethane.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin

        DB_DIYETEntities db = new DB_DIYETEntities();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = db.TBLDIYETLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Iletisim()
        {
            return View();
        }
      
        
        [HttpPost]
        public ActionResult Iletisim(TBLILETISIM t)
        {
            db.TBLILETISIM.Add(t);
            db.SaveChanges();
            return View();
        }
    
        public ActionResult Hakkimizda()
        {
            return View();
        }
    }
}