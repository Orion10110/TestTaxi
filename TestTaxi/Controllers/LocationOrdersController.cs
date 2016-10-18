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
    public class LocationOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LocationOrders
        public ActionResult Index(int page = 1)
        {
            int pageSize = 10;
            IEnumerable<LocationOrder> lOPerPages = db.LocationOrders.Include(l => l.Order).Include(l => l.StreetFrom).Include(l => l.StreetTo).
                OrderBy(p => p.DateOrder).Skip((page - 1) *
                pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = db.LocationOrders.Count()
            };
            MyIndexViewModel<LocationOrder> ivm = new MyIndexViewModel<LocationOrder>
            {
                PageInfo = pageInfo,
                Keeps = lOPerPages
            };

            return View(ivm);
        }

        // GET: LocationOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationOrder locationOrder = db.LocationOrders.Find(id);
            if (locationOrder == null)
            {
                return HttpNotFound();
            }
            return View(locationOrder);
        }

        // GET: LocationOrders/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Orders, "Id", "ApplicationUserID");
            ViewBag.StreetFromID = new SelectList(db.Streets, "Id", "Name");
            ViewBag.StreetToID = new SelectList(db.Streets, "Id", "Name");
            return View();
        }

        // POST: LocationOrders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PhoneNumber,DateOrder,DateComeFrom,DateComeIn,AddressFrom,AddressTo,StreetFromID,StreetToID")] LocationOrder locationOrder)
        {
            if (ModelState.IsValid)
            {
                db.LocationOrders.Add(locationOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Orders, "Id", "ApplicationUserID", locationOrder.Id);
            ViewBag.StreetFromID = new SelectList(db.Streets, "Id", "Name", locationOrder.StreetFromID);
            ViewBag.StreetToID = new SelectList(db.Streets, "Id", "Name", locationOrder.StreetToID);
            return View(locationOrder);
        }

        // GET: LocationOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationOrder locationOrder = db.LocationOrders.Find(id);
            if (locationOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Orders, "Id", "ApplicationUserID", locationOrder.Id);
            ViewBag.StreetFromID = new SelectList(db.Streets, "Id", "Name", locationOrder.StreetFromID);
            ViewBag.StreetToID = new SelectList(db.Streets, "Id", "Name", locationOrder.StreetToID);
            return View(locationOrder);
        }

        // POST: LocationOrders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PhoneNumber,DateOrder,DateComeFrom,DateComeIn,AddressFrom,AddressTo,StreetFromID,StreetToID")] LocationOrder locationOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Orders, "Id", "ApplicationUserID", locationOrder.Id);
            ViewBag.StreetFromID = new SelectList(db.Streets, "Id", "Name", locationOrder.StreetFromID);
            ViewBag.StreetToID = new SelectList(db.Streets, "Id", "Name", locationOrder.StreetToID);
            return View(locationOrder);
        }

        // GET: LocationOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationOrder locationOrder = db.LocationOrders.Find(id);
            if (locationOrder == null)
            {
                return HttpNotFound();
            }
            return View(locationOrder);
        }

        // POST: LocationOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocationOrder locationOrder = db.LocationOrders.Find(id);
            db.LocationOrders.Remove(locationOrder);
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
