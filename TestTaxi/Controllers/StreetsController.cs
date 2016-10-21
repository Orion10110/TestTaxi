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
    public class StreetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Streets
        public ActionResult Index(int page = 1, int districtF = 0)
        {
            List<District> listDistrict = db.Districts.ToList();
            listDistrict.Insert(0, new District { Name = "Все", Id = 0 });
            

            SelectList district = new SelectList(listDistrict, "Id", "Name");
         

            ViewBag.District = district;
            int pageSize = 10;


            IEnumerable<Street> streetPerPages = db.Streets.Include(c => c.District);
           
            if (districtF != 0)
            {
                streetPerPages = streetPerPages.Where(p => p.District.Id == districtF);
            }
          
            int pages = streetPerPages.Count();
            streetPerPages = streetPerPages.OrderBy(p => p.Name).Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = pages
            };
            MyIndexViewModel<Street> ivm = new MyIndexViewModel<Street>
            {
                PageInfo = pageInfo,
                Keeps = streetPerPages
            };
            return View(ivm);
        }

        // GET: Streets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        // GET: Streets/Create
        public ActionResult Create()
        {
            ViewBag.DistrictID = new SelectList(db.Districts, "Id", "Name");
            return View();
        }

        // POST: Streets/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DistrictID")] Street street)
        {
            if (ModelState.IsValid)
            {
                db.Streets.Add(street);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictID = new SelectList(db.Districts, "Id", "Name", street.DistrictID);
            return View(street);
        }

        // GET: Streets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictID = new SelectList(db.Districts, "Id", "Name", street.DistrictID);
            return View(street);
        }

        // POST: Streets/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DistrictID")] Street street)
        {
            if (ModelState.IsValid)
            {
                db.Entry(street).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictID = new SelectList(db.Districts, "Id", "Name", street.DistrictID);
            return View(street);
        }

        // GET: Streets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        // POST: Streets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Street street = db.Streets.Find(id);
            db.Streets.Remove(street);
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
