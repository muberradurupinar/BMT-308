﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDiyethane.Models.Entity;

namespace MVCDiyethane.Controllers
{
    public class KayitController : Controller
    {
        // GET: Kayit
        DB_DIYETEntities db = new DB_DIYETEntities();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(TBLUYELER p)
        {
           if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBLUYELER.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}