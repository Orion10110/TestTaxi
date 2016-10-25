using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTaxi.Models;

namespace TestTaxi.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        // GET: Report
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {          
            string id = User.Identity.GetUserId();
            IEnumerable<Order> rep = db.Orders.Where(s => s.ApplicationUserID == id).Include(o => o.Client).Include(o => o.Driver).Include(o => o.StreetFrom).Include(o => o.StreetTo);
            DateTime startDateTime = DateTime.Today; //Today at 00:00:00
            DateTime endDateTime = DateTime.Today.AddDays(1).AddTicks(-1);
            IEnumerable<Order> todayOrd = rep.Where(c => c.DateOrder >= startDateTime && c.DateOrder < endDateTime);
            int countTodey = todayOrd.Count();
            int countExutabl = todayOrd.Where(c => c.status == Status.ЗАВЕРШЕН).Count();
            int countCance = todayOrd.Where(c => c.status == Status.ОТМЕНЕН).Count();
            ViewBag.CountOrder = countTodey;
            ViewBag.CountEx = countExutabl;
            ViewBag.CountCa = countCance;
            return View(todayOrd);

        }
    }
}