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
    public class ValueTaximetersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ValueTaximeters
        public ActionResult Index(int page = 1)
        {
            int pageSize = 10;
            IEnumerable<ValueTaximeter> vTPerPages = db.ValueTaximeters.Include(v => v.Order).OrderBy(p => p.Id).Skip((page - 1) *
                pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = db.ValueTaximeters.Count()
            };
            MyIndexViewModel<ValueTaximeter> ivm = new MyIndexViewModel<ValueTaximeter>
            {
                PageInfo = pageInfo,
                Keeps = vTPerPages
            };
            return View(ivm);
        }

        // GET: ValueTaximeters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValueTaximeter valueTaximeter = db.ValueTaximeters.Find(id);
            if (valueTaximeter == null)
            {
                return HttpNotFound();
            }
            return View(valueTaximeter);
        }

        // GET: ValueTaximeters/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Orders, "Id", "Id");
            return View();
        }

        // POST: ValueTaximeters/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartValue,EndValue")] ValueTaximeter valueTaximeter)
        {
            if (ModelState.IsValid)
            {
                db.ValueTaximeters.Add(valueTaximeter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Orders, "Id", "Id", valueTaximeter.Id);
            return View(valueTaximeter);
        }

        // GET: ValueTaximeters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValueTaximeter valueTaximeter = db.ValueTaximeters.Find(id);
            if (valueTaximeter == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Orders, "Id", "Id", valueTaximeter.Id);
            return View(valueTaximeter);
        }

        // POST: ValueTaximeters/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartValue,EndValue")] ValueTaximeter valueTaximeter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valueTaximeter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Orders, "Id", "Id", valueTaximeter.Id);
            return View(valueTaximeter);
        }

        // GET: ValueTaximeters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValueTaximeter valueTaximeter = db.ValueTaximeters.Find(id);
            if (valueTaximeter == null)
            {
                return HttpNotFound();
            }
            return View(valueTaximeter);
        }

        // POST: ValueTaximeters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ValueTaximeter valueTaximeter = db.ValueTaximeters.Find(id);
            db.ValueTaximeters.Remove(valueTaximeter);
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
