using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestTaxi.Models;
using Microsoft.AspNet.Identity;

namespace TestTaxi.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index(int page = 1,int status = 0)
        {
            //List<Status> listBrand = new List<Status>() { Status.ВСЕ, Status.ЗАВЕРШЕН, Status.ОБРАБАТЫВАЕТСЯ, Status.ПРИНЯТ };
            //SelectList status = new SelectList(listBrand, "Status", "Status");
            int pageSize = 10;
            string id = User.Identity.GetUserId();
            IEnumerable<Order> orderPerPages = db.Orders.Where(s=>s.ApplicationUserID == id).Include(o => o.Client).Include(o => o.Driver).Include(o => o.StreetFrom).Include(o => o.StreetTo)
                .OrderBy(p => p.DateOrder).Skip((page - 1) *
                pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = db.Orders.Count()
            };
            MyIndexViewModel<Order> ivm = new MyIndexViewModel<Order>
            {
                PageInfo = pageInfo,
                Keeps = orderPerPages
            };

            return View(ivm);
         
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "Id", "FirstName");
            ViewBag.DriverID = new SelectList(db.Drivers, "Id", "FirstName");
            ViewBag.StreetFromID = new SelectList(db.Streets, "Id", "Name");
            ViewBag.StreetToID = new SelectList(db.Streets, "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,status,PhoneNumber,DateOrder,ClientID,DriverID,StreetFromID,StreetToID,StartValue,EndValue")] Order order)
        {
            string idUser= User.Identity.GetUserId();
            order.ApplicationUserID = idUser;
            
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "Id", "SecondName", order.ClientID);
            ViewBag.DriverID = new SelectList(db.Drivers, "Id", "SecondName", order.DriverID);
            ViewBag.StreetFromID = new SelectList(db.Streets, "Id", "Name", order.StreetFromID);
            ViewBag.StreetToID = new SelectList(db.Streets, "Id", "Name", order.StreetToID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "Id", "SecondName", order.ClientID);
            ViewBag.DriverID = new SelectList(db.Drivers, "Id", "SecondName", order.DriverID);
            ViewBag.StreetFromID = new SelectList(db.Streets, "Id", "Name", order.StreetFromID);
            ViewBag.StreetToID = new SelectList(db.Streets, "Id", "Name", order.StreetToID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,status,PhoneNumber,DateOrder,ClientID,DriverID,StreetFromID,StreetToID,StartValue,EndValue")] Order order)
        {
            string idUser = User.Identity.GetUserId();
            order.ApplicationUserID = idUser;
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "Id", "FirstName", order.ClientID);
            ViewBag.DriverID = new SelectList(db.Drivers, "Id", "FirstName", order.DriverID);
            ViewBag.StreetFromID = new SelectList(db.Streets, "Id", "Name", order.StreetFromID);
            ViewBag.StreetToID = new SelectList(db.Streets, "Id", "Name", order.StreetToID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
