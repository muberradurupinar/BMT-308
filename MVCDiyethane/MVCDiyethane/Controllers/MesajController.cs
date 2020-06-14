using MVCDiyethane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDiyethane.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        DB_DIYETEntities db = new DB_DIYETEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLILETISIM.ToList();
            return View(degerler);
        }
        
    }
}