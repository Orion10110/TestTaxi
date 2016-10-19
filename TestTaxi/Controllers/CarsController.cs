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
    public class CarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cars
        public ActionResult Index(int page=1, int typeCar=0,int brandCar=0)
        {
            List<Brand> listBrand = db.Brands.ToList();
            listBrand.Insert(0, new Brand { Name = "Все", Id = 0 });
            List<TypeCar> listType = db.TypeCars.ToList();
            listType.Insert(0, new TypeCar { Type = "Все", Id = 0 });

            SelectList brand = new SelectList(listBrand, "Id", "Name");
            SelectList type = new SelectList(listType, "Id", "Type");

            
            ViewBag.TypeOfCar = type;
            ViewBag.BrandOfCar = brand;
            int pageSize = 10;


            IEnumerable<Car> carPerPages = db.Cars.Include(c => c.Brand).Include(c => c.TypeCar);
            //IEnumerable<Car> carPerPages = db.Cars.Include(c => c.Brand).Include(c => c.TypeCar).OrderBy(p => p.Name).Skip((page - 1) *
            //    pageSize).Take(pageSize);

            if ( typeCar != 0)
            {
                carPerPages = carPerPages.Where(p => p.TypeCar.Id == typeCar);
            }
            if (brandCar!=0)
            {
                carPerPages = carPerPages.Where(p => p.Brand.Id == brandCar);
            }
            int pages = carPerPages.Count();
            carPerPages =carPerPages.OrderBy(p => p.Name).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = pages
            };
            MyIndexViewModel<Car> ivm = new MyIndexViewModel<Car>
            {
                PageInfo = pageInfo,
                Keeps = carPerPages
            };
            return View(ivm);
           
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name");
            ViewBag.TypeCarId = new SelectList(db.TypeCars, "Id", "Type");
            return View();
        }

        // POST: Cars/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BrandId,Name,TypeCarId,Place,GosNumbet,Stars,Active")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", car.BrandId);
            ViewBag.TypeCarId = new SelectList(db.TypeCars, "Id", "Type", car.TypeCarId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", car.BrandId);
            ViewBag.TypeCarId = new SelectList(db.TypeCars, "Id", "Type", car.TypeCarId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BrandId,Name,TypeCarId,Place,GosNumbet,Stars,Active")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "Id", "Name", car.BrandId);
            ViewBag.TypeCarId = new SelectList(db.TypeCars, "Id", "Type", car.TypeCarId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
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
