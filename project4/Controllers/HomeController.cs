using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project4.Models;
using Microsoft.EntityFrameworkCore;

namespace project4.Controllers
{
    public class HomeController : Controller
    {
        DiscContext db;
        public HomeController(DiscContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Discs.ToList());
        }
        [HttpGet]
        public IActionResult Buy(int? id)
        {
            return View();
        }
    }

}
