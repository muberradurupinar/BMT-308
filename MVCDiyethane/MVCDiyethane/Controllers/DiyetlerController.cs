using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDiyethane.Models.Entity;
namespace MVCDiyethane.Controllers
{
    public class DiyetlerController : Controller
    {
        // GET: Diyetler
        DB_DIYETEntities db = new DB_DIYETEntities();
        [Authorize]
        public ActionResult Index(string p)
        {
            var diyetler = from k in db.TBLDIYETLER select k;
            if (!string.IsNullOrEmpty(p))
            {
                diyetler = diyetler.Where(m => m.AD.Contains(p));
            }
            // var kitaplar = db.TBLKITAP.ToList();
            return View(diyetler.ToList());
        }
        [HttpGet]
        public ActionResult DiyetEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult DiyetEkle(TBLDIYETLER p)
        {
            var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
            p.TBLKATEGORI = ktg;
            p.TBLYAZAR = yzr;
            db.TBLDIYETLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DiyetSil(int id)
        {
            var diyet = db.TBLDIYETLER.Find(id);
            db.TBLDIYETLER.Remove(diyet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DiyetGetir(int id)
        {
            var ktp = db.TBLDIYETLER.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View("DiyetGetir", ktp);
        }
        public ActionResult DiyetGuncelle(TBLDIYETLER p)
        {
            var diyet = db.TBLDIYETLER.Find(p.ID);
            diyet.AD = p.AD;
            var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
            diyet.KATEGORI = ktg.ID;
            diyet.YAZAR = yzr.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}