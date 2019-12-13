using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project4.Models;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Net;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project4.Controllers
{
    public class CdController : Controller
    {
        DiscContext db;
        public CdController(DiscContext context)
        {
            db = context;
        }

    
        public IActionResult Cd(string ? text)
        {
            if (text != null && text.Trim() != "") {
                var discs = db.Discs
                .Where(c => c.Name.Contains(text) ||
                    c.Artist.Contains(text) ||
                    c.ID.ToString().Contains(text) ||
                    c.Count.ToString().Contains(text));

                return View(discs);
            }
            else {
                return View(db.Discs.ToList());
            }
        }
        

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Disc disc)
        {
            db.Discs.Add(disc); 
            db.SaveChanges();
            return View();
        }

        public IActionResult Delete(int? ID)
        {
            if (ID == null) {
                return new BadRequestResult();
            }
            Disc disc = db.Discs.Find(ID);
            if (disc == null) {
                return new NotFoundResult();
            }
            db.Discs.Remove(db.Discs.Find(ID));
            db.SaveChanges();
            return Redirect("/Cd/Cd");
        }

        public IActionResult Detail(int ? ID)
        {
            if (ID == null) {
                return new BadRequestResult();
            }
            Disc disc = db.Discs.Find(ID);
            if (disc == null) {
                return new NotFoundResult();
            }
            ViewBag.Name = disc.Name;
            ViewBag.ID = disc.ID;
            ViewBag.Count = disc.Count;
            ViewBag.Artist = disc.Artist;

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int ? ID)
        {
            if (ID == null) {
                return new BadRequestResult();
            }
            Disc disc = db.Discs.Find(ID);
            if (disc == null) {
                return new NotFoundResult();
            }
            ViewBag.Name = disc.Name;
            ViewBag.ID = disc.ID;
            ViewBag.Count = disc.Count;
            ViewBag.Artist = disc.Artist;

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Disc disc)
        {
            if (disc == null) {
                return new BadRequestResult();
            }
            
            Disc disc2 = db.Discs.Find(disc.ID);
            disc2.Artist = disc.Artist;
            disc2.Name = disc.Name;
            disc2.Count = disc.Count;
            db.SaveChanges();

            return Redirect("/Cd/Cd");
        }

    }
}
