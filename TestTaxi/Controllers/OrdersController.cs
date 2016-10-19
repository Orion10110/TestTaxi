using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestTaxi.Models;

namespace TestTaxi.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index(int page = 1)
        {
            int pageSize = 10;
            IEnumerable<Order> orderPerPages = db.Orders.Include(o => o.Client).Include(o => o.Driver).Include(o => o.LocationOrder).Include(o => o.ValueTaximeter).
                OrderBy(p => p.status).Skip((page - 1) *
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
            ViewBag.ClientID = new SelectList(db.Clients, "Id", "SecondName");
            ViewBag.DriverID = new SelectList(db.Drivers, "Id", "SecondName");
            ViewBag.Id = new SelectList(db.LocationOrders, "Id", "PhoneNumber");
            ViewBag.Id = new SelectList(db.ValueTaximeters, "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,status,ClientID,DriverID,ApplicationUserID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "Id", "SecondName", order.ClientID);
            ViewBag.DriverID = new SelectList(db.Drivers, "Id", "SecondName", order.DriverID);
            ViewBag.Id = new SelectList(db.LocationOrders, "Id", "PhoneNumber", order.Id);
            ViewBag.Id = new SelectList(db.ValueTaximeters, "Id", "Id", order.Id);
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
            ViewBag.Id = new SelectList(db.LocationOrders, "Id", "Id", order.Id);
            ViewBag.Id = new SelectList(db.ValueTaximeters, "Id", "Id", order.Id);
            return View(order);
        }

        // POST: Orders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,status,ClientID,DriverID,ApplicationUserID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "Id", "FirstName", order.ClientID);
            ViewBag.DriverID = new SelectList(db.Drivers, "Id", "FirstName", order.DriverID);
            ViewBag.Id = new SelectList(db.LocationOrders, "Id", "PhoneNumber", order.Id);
            ViewBag.Id = new SelectList(db.ValueTaximeters, "Id", "Id", order.Id);
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
