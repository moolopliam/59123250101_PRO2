using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class ChairController : Controller
    {
        private readonly Cinema5927Entities db = new Cinema5927Entities();

        // GET: Chair
        public ActionResult Index()
        {
            var table_Chair = db.Table_Chair.Include(t => t.Table_Screen).Include(t => t.Table_StatusChire);
            return View(table_Chair.ToList());
        }

        // GET: Chair/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var table_Chair = db.Table_Chair.Find(id);
            if (table_Chair == null) return HttpNotFound();
            return View(table_Chair);
        }

        // GET: Chair/Create
        public ActionResult Create()
        {
            ViewBag.C_ScreenID = new SelectList(db.Table_Screen, "S_ScreenID", "S_DateSN");
            ViewBag.C_SatatusID = new SelectList(db.Table_StatusChire, "S_StatusChireID", "S_NameSta");
            return View();
        }

        // POST: Chair/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_ChairID,C_NameChair,C_SatatusID,C_ScreenID,C_Price")]
            Table_Chair table_Chair)
        {
            if (ModelState.IsValid)
            {
                db.Table_Chair.Add(table_Chair);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.C_ScreenID = new SelectList(db.Table_Screen, "S_ScreenID", "S_DateSN", table_Chair.C_ScreenID);
            ViewBag.C_SatatusID = new SelectList(db.Table_StatusChire, "S_StatusChireID", "S_NameSta",
                table_Chair.C_SatatusID);
            return View(table_Chair);
        }

        // GET: Chair/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var table_Chair = db.Table_Chair.Find(id);
            if (table_Chair == null) return HttpNotFound();
            ViewBag.C_ScreenID = new SelectList(db.Table_Screen, "S_ScreenID", "S_DateSN", table_Chair.C_ScreenID);
            ViewBag.C_SatatusID = new SelectList(db.Table_StatusChire, "S_StatusChireID", "S_NameSta",
                table_Chair.C_SatatusID);
            return View(table_Chair);
        }

        // POST: Chair/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_ChairID,C_NameChair,C_SatatusID,C_ScreenID,C_Price")]
            Table_Chair table_Chair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Chair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.C_ScreenID = new SelectList(db.Table_Screen, "S_ScreenID", "S_DateSN", table_Chair.C_ScreenID);
            ViewBag.C_SatatusID = new SelectList(db.Table_StatusChire, "S_StatusChireID", "S_NameSta",
                table_Chair.C_SatatusID);
            return View(table_Chair);
        }

        // GET: Chair/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var table_Chair = db.Table_Chair.Find(id);
            if (table_Chair == null) return HttpNotFound();
            return View(table_Chair);
        }

        // POST: Chair/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var table_Chair = db.Table_Chair.Find(id);
            db.Table_Chair.Remove(table_Chair);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}