using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class OderAdminController : Controller
    {
        private readonly Cinema5927Entities db = new Cinema5927Entities();

        // GET: OderAdmin
        public ActionResult Index()
        {
            var data = db.Table_Order.Where(a => a.O_SatatusBay == 1).ToList();
            return View(data);
        }
        public ActionResult Index2()
        {
            var data = db.Table_Order.Where(a => a.O_SatatusBay == 3).ToList();
            return View(data);
        }
        public ActionResult Index3()
        {
            var data = db.Table_Order.Where(a => a.O_SatatusBay == 2).ToList();
            return View(data);
        }

        public ActionResult ListProduct(int id)
        {
            var data = db.Table_DetailOder.Where(a => a.D_Order == id).ToList();
            ViewBag.totoalP = data.Sum(a => a.Table_Chair.C_Price);
            return View(data);
        }

        public ActionResult Confirm(int id)
        {
            var data = db.Table_Order.Where(a => a.O_OrderID == id).FirstOrDefault();
            data.O_SatatusBay = 3;
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Evidence(int id)
        {
            var data = db.Table_Order.Where(a => a.O_OrderID == id).FirstOrDefault();
            return View(data);
        }

    }
}