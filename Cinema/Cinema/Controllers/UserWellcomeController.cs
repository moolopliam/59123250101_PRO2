using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class UserWellcomeController : Controller
    {
        private readonly Cinema5927Entities db = new Cinema5927Entities();

        // GET: UserWellcome
        public ActionResult Index()
        {
            Session["typeid"] = 111;
            var data = db.Table_Movie.Where(a => a.M_MovieStatus == 1).ToList();
            foreach (var itMovie in data)
            {
                var dateI = Convert.ToDateTime(itMovie.M_DateInMovie);
                var dateO = Convert.ToDateTime(itMovie.M_DateOutMovie);
                itMovie.M_DateInMovie = dateI.ToString("dd/MM/yyyy");
                itMovie.M_DateOutMovie = dateO.ToString("dd/MM/yyyy");
            }

            return View(data);
        }

        public JsonResult searchPrice(int id)
        {
            var value = db.Table_Chair.Where(a => a.C_ChairID == id).FirstOrDefault();
            var data = value.C_Price;
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddChir(int[] myarray)
        {
            if (Session["U_EMAIL"] != null)
            {
                var emailid = Session["U_EMAIL"].ToString();
                var data = db.Table_Order.Where(a => a.O_Email == emailid && a.O_SatatusBay == 2).FirstOrDefault();
                foreach (var item in myarray)
                {
                    var AddChirvalue = new Table_DetailOder
                    {
                        D_Order = data.O_OrderID,
                        D_hairID = item
                    };
                    db.Table_DetailOder.Add(AddChirvalue);
                    var ChirCK = db.Table_Chair.Where(a => a.C_ChairID == item).FirstOrDefault();
                    ChirCK.C_SatatusID = 1;
                    db.Entry(ChirCK).State = EntityState.Modified;
                }

                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Login", "User");
        }

        public ActionResult Chair(int id)
        {
            var data = db.Table_Chair.Where(a => a.C_ScreenID == id).ToList();
            return View(data);
        }

        public ActionResult ListSecn(int id)
        {
            var data = db.Table_Screen.Where(a => a.S_MovieID == id && a.S_StatusSN == 2).ToList();
            foreach (var iScreen in data)
            {
                var date = Convert.ToDateTime(iScreen.S_DateSN);
                iScreen.S_DateSN = date.ToString("dd/MM/yyyy");
            }

            return View(data);
        }

        public ActionResult OrderDetail()
        {
            var emailid = Session["U_EMAIL"].ToString();
            var data = db.Table_Order.Where(a => a.O_Email == emailid && a.O_SatatusBay != 2).ToList();
            return View(data);
        }

        public ActionResult OrderDetail2()
        {
            var emailid = Session["U_EMAIL"].ToString();
            var data = db.Table_Order.Where(a => a.O_Email == emailid && a.O_SatatusBay == 2).ToList();
            return View(data);
        }

        public ActionResult OrDetail(int id)
        {
            TempData["totalprice"] = 0;
            var data = db.Table_DetailOder.Where(a => a.D_Order == id).ToList();
            TempData["totalprice"] = data.Sum(a => a.Table_Chair.C_Price);
            return View(data);
        }

        public ActionResult Pay(int id)
        {
            TempData["totalp"] = 0;
            var data = db.Table_Order.Where(a => a.O_OrderID == id).FirstOrDefault();
            var C = db.Table_DetailOder.Where(a => a.D_Order == id).ToList();
            TempData["totalp"] = C.Sum(a => a.Table_Chair.C_Price);
            return View(data);
        }

        [HttpPost]
        public ActionResult Pay(Table_Order data)
        {
            var email = data.O_Email;
            if (data.UplPostedFile != null)
            {
                if (data.O_Total > 0)
                {
                    var Temp = new byte[data.UplPostedFile.ContentLength];
                    data.UplPostedFile.InputStream.Read(Temp, 0, data.UplPostedFile.ContentLength);
                    data.O_IMGPAY = Temp;

                    data.O_SatatusBay = 1;
                    db.Entry(data).State = EntityState.Modified;

                    var date = DateTime.Now.ToString("dd/MM/yyyy");
                    var _Order = new Table_Order
                    {
                        O_DateOder = date,
                        O_OrderID = 2,
                        O_Email = email,
                        O_SatatusBay = 2
                    };
                    db.Table_Order.Add(_Order);
                    db.SaveChanges();
                    return RedirectToAction(nameof(OrderDetail));
                }

                ModelState.AddModelError("O_Total", "ยังไม่ได้เลือกรายการสินค้า");
            }

            ModelState.AddModelError("UplPostedFile", "กรูณาอัพโหลดรูปสลิปเงิน");
            return View(data);
        }

        public ActionResult RemovPayList(int id, int orid)
        {
            var data = db.Table_DetailOder.Where(a => a.D_DetailOderID == id).FirstOrDefault();
            db.Table_DetailOder.Remove(data);
            db.SaveChanges();
            return RedirectToAction(nameof(OrderDetail2), new {id = orid});
        }
    }
}