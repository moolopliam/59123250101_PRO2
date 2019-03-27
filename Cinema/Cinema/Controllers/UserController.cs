using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class UserController : Controller
    {
        private readonly Cinema5927Entities db = new Cinema5927Entities();
        // GET: User

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Table_User data)
        {
            var CKMAILL = db.Table_User.Where(a => a.U_EmailID == data.U_EmailID).FirstOrDefault();
            var CKPASS = db.Table_User.Where(a => a.U_Password == data.U_Password).FirstOrDefault();
            Session["typeid"] = 111;
            if (CKMAILL == null)
            {
                ModelState.AddModelError("U_EmailID", "ไม่พบข้อมูลอีเมลล์ของคุณ");
            }
            else if (CKMAILL != null)
            {
                if (CKPASS == null)
                {
                    ModelState.AddModelError("U_Password", "รหัสผ่านของคุณผิด");
                }
                else
                {
                    if (CKMAILL.U_TypeID == 1)
                    {
                        Session["U_EMAIL"] = CKMAILL.U_EmailID;
                        Session["U_NAME"] = CKMAILL.U_Name + CKMAILL.U_LastName;
                        Session["typeid"] = 1;
                        AddOrder(CKMAILL.U_EmailID, CKMAILL.U_TypeID);
                        return RedirectToAction("Index", "UserWellcome");
                    }
                    else
                    {
                        Session["U_EMAIL"] = CKMAILL.U_EmailID;
                        Session["typeid"] = 2;
                        Session["U_NAME"] = CKMAILL.U_Name + CKMAILL.U_LastName;
                        return RedirectToAction("Index", "Movie");
                    }

                }
            }

            return View(data);
        }

        public void AddOrder(string Email, int? TypeUser)
        {
            var i = 0;
            var r = 0;

            var HKoRder = db.Table_Order.Where(a => a.O_Email == Email).ToList();
            if (TypeUser == 1)
            {
                if (HKoRder.Count == 0) AddValue(Email, TypeUser);
                foreach (var item in HKoRder)
                {
                    if (item.O_SatatusBay == 1) i++;
                    if (item.O_SatatusBay == 2) r++;
                }

                if (i != 0)
                {
                    if (r == 0) AddValue(Email, TypeUser);
                }
                else
                {
                    if (HKoRder.Count > 0)
                        if (r == 0)
                            AddValue(Email, TypeUser);
                }
            }
        }

        public void AddValue(string Email, int? TypeUser)
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            var _Order = new Table_Order
            {
                O_DateOder = date,
                O_OrderID = 2,
                O_Email = Email,
                O_SatatusBay = 2
            };
            db.Table_Order.Add(_Order);
            db.SaveChanges();
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "UserWellcome");
        }

        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult register(Table_User data)
        {
            data.U_TypeID = 1;
            if (ModelState.IsValid)
            {
                db.Table_User.Add(data);
                db.SaveChanges();
                return RedirectToAction(nameof(Login));
            }

            return View(data);
        }

        public ActionResult EditProfileUser()
        {
            if (Session["U_EMAIL"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            var id = Session["U_EMAIL"].ToString();
            var data = db.Table_User.Where(a => a.U_EmailID == id).FirstOrDefault();
       
            return View(data);
        }
        [HttpPost]
        public ActionResult EditProfileUser(Table_User data)
        {
            if (ModelState.IsValid)
            {
                Session["U_NAME"] = data.U_Name + data.U_LastName;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "UserWellcome");
            }
            return View(data);
        }

    }
}