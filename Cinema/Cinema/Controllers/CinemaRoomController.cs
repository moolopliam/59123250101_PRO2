using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class CinemaRoomController : Controller
    {
        // GET: Movie
        private readonly Cinema5927Entities db = new Cinema5927Entities();

        public ActionResult Index(int CHK = 0)
        {
            TempData["CHK"] = 0;
            if (CHK != 0) TempData["CHK"] = CHK;
            var data = db.Table_Cinema.ToList(); //แสดงข้อมูลเป็นรายการ
            return View(data); //ส่งข้อมูลไปแสดง
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id) //รับ PK เข้ามาเพื่อค้นข้อมูล
        {
            var data = db.Table_Cinema.Where(b => b.C_CinemaID == id)
                .FirstOrDefault(); //ค้นหาข้อมูลเพียงค่าเดียวเพื่อแก้ไข
            return View(data); //ส่งข้อมูลไปแสดง
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View(); //แสดงแบบฟอร์มกรอกข้อมูล
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Table_Cinema data) //ส่งข้อมูลที่กรอกแล้วเข้ามา
        {
            try
            {
                data.C_AmoutHire = 120;
                if (ModelState.IsValid) //เช็ดข้อมูล
                {
                    db.Table_Cinema.Add(data); //เพิ่มข้อมูล
                    db.SaveChanges(); // บันทึก
                    return RedirectToAction("Index", new {CHK = 1}); //ไปหน้า index
                }

                return View(data); // ถ้าข้อมูลไม่ครบแสดงข้อมูลเดิม  และแสดงแจ้งเตือน
            }
            catch
            {
                return View(data);
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id) //รับ PK เข้ามาเพื่อค้นข้อมูล
        {
            var data = db.Table_Cinema.Where(b => b.C_CinemaID == id)
                .FirstOrDefault(); //ค้นหาข้อมูลเพียงค่าเดียวเพื่อแก้ไข

            return View(data); //ส่งข้อมูลไปแสดง
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(Table_Cinema data) //ส่งข้อมูลที่แก้ไขแล้วเข้ามา
        {
            try
            {
                if (ModelState.IsValid) //เช็ดข้อมูล
                {
                    db.Entry(data).State = EntityState.Modified; //แก้ไขข้อมูล
                    db.SaveChanges(); //บันทึก
                    return RedirectToAction("Index", new {CHK = 1}); //ไปหน้า index
                }

                return View(data);
            }
            catch
            {
                return View(data);
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id) //รับ PK เข้ามาเพื่อค้นข้อมูล
        {
            try
            {
                var CK = db.Table_Screen.Where(a => a.S_MovieID == id)
                    .ToList(); //ค้นหาข้อมูลว่า idหนังถูกให้งานหรือป่าว
                if (CK.Count == 0) //==0แสดงว่าไม่ถูกใช้ลบได้
                {
                    var data = db.Table_Cinema.Where(b => b.C_CinemaID == id)
                        .FirstOrDefault(); //ค้นหาข้อมูลเพียงค่าเดียวเพื่อแก้ไข
                    db.Table_Cinema.Remove(data); // ลบข้อมูล
                    db.SaveChanges(); //บันทึก
                    return RedirectToAction(nameof(Index), new {CHK = 2}); //ไปหน้า index
                }

                return RedirectToAction(nameof(Index), new {CHK = 3}); //ไปหน้า index
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}