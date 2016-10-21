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
    [Authorize]
    public class TypeCarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TypeCars
        public ActionResult Index(int page=1, string filtr="")
        {
            ViewBag.Filtr = filtr;
            int pageSize = 10;
            IEnumerable<TypeCar> typesPerPages = db.TypeCars.Where(n => n.Type.Contains(filtr)).OrderBy(p => p.Type).Skip((page - 1) *
                pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = db.TypeCars.Where(n => n.Type.Contains(filtr)).Count()
            };
            MyIndexViewModel<TypeCar> ivm = new MyIndexViewModel<TypeCar>
            {
                PageInfo = pageInfo,
                Keeps = typesPerPages
            };
            return View(ivm);
        }

        // GET: TypeCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeCar typeCar = db.TypeCars.Find(id);
            if (typeCar == null)
            {
                return HttpNotFound();
            }
            return View(typeCar);
        }

        // GET: TypeCars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeCars/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type")] TypeCar typeCar)
        {
            if (ModelState.IsValid)
            {
                db.TypeCars.Add(typeCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeCar);
        }

        // GET: TypeCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeCar typeCar = db.TypeCars.Find(id);
            if (typeCar == null)
            {
                return HttpNotFound();
            }
            return View(typeCar);
        }

        // POST: TypeCars/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type")] TypeCar typeCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeCar);
        }

        // GET: TypeCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeCar typeCar = db.TypeCars.Find(id);
            if (typeCar == null)
            {
                return HttpNotFound();
            }
            return View(typeCar);
        }

        // POST: TypeCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeCar typeCar = db.TypeCars.Find(id);
            db.TypeCars.Remove(typeCar);
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
