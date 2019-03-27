using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class ScreenController : Controller
    {
        // GET: Movie
        private readonly Cinema5927Entities db = new Cinema5927Entities();

        public ActionResult Index(int CHK = 0)
        {
            TempData["CHK"] = 0;
            if (CHK != 0) TempData["CHK"] = CHK;
            var data = db.Table_Screen.ToList(); //แสดงข้อมูลเป็นรายการ
            return View(data); //ส่งข้อมูลไปแสดง
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id) //รับ PK เข้ามาเพื่อค้นข้อมูล
        {
            var data = db.Table_Chair.Where(b => b.C_ScreenID == id).ToList(); //ค้นหาข้อมูลเพียงค่าเดียวเพื่อแก้ไข
            return View(data); //ส่งข้อมูลไปแสดง
        }


        // GET: Movie/Create
        public ActionResult Create()
        {
            ViewBag.S_CinemaID = new SelectList(db.Table_Cinema, "C_CinemaID", "C_Name");
            ViewBag.S_MovieID = new SelectList(db.Table_Movie, "M_MovieID", "M_NameMovie");

            return View(); //แสดงแบบฟอร์มกรอกข้อมูล
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Table_Screen data) //ส่งข้อมูลที่กรอกแล้วเข้ามา
        {
            ViewBag.S_CinemaID = new SelectList(db.Table_Cinema, "C_CinemaID", "C_Name");
            ViewBag.S_MovieID = new SelectList(db.Table_Movie, "M_MovieID", "M_NameMovie");

            try
            {
                if (ModelState.IsValid) //เช็ดข้อมูล
                {
                    data.S_StatusSN = 1;
                    db.Table_Screen.Add(data); //เพิ่มข้อมูล
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

        public ActionResult AddChair(int idSen)
        {
            var namerow = "A";
            var price = 150;
            var secen = db.Table_Screen.Where(a => a.S_ScreenID == idSen).FirstOrDefault();
            var cinema = db.Table_Cinema.Where(a => a.C_CinemaID == secen.S_CinemaID).FirstOrDefault();
            var Chair = new List<Table_Chair>();
            for (var i = 1; i <= cinema.C_AmoutHire; i++)
            {
                if (i == 21)
                {
                    price = 150;
                    namerow = "B";
                }
                else if (i == 41)
                {
                    price = 150;
                    namerow = "C";
                }
                else if (i == 61)
                {
                    price = 150;
                    namerow = "D";
                }
                else if (i == 81)
                {
                    price = 300;
                    namerow = "E";
                }
                else if (i == 101)
                {
                    price = 300;
                    namerow = "F";
                }

                Chair.Add(new Table_Chair
                    {C_ScreenID = idSen, C_NameChair = namerow + i, C_SatatusID = 2, C_Price = price});
            }

            db.Table_Chair.AddRange(Chair);
            secen.S_StatusSN = 2;
            db.Entry(secen).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction(nameof(Index), new {CHK = 1});
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id) //รับ PK เข้ามาเพื่อค้นข้อมูล
        {
            var data = db.Table_Screen.Where(b => b.S_ScreenID == id)
                .FirstOrDefault(); //ค้นหาข้อมูลเพียงค่าเดียวเพื่อแก้ไข
            ViewBag.S_CinemaID = new SelectList(db.Table_Cinema, "C_CinemaID", "C_Name", data.S_ScreenID);
            ViewBag.S_MovieID = new SelectList(db.Table_Movie, "M_MovieID", "M_NameMovie", data.S_MovieID);


            return View(data); //ส่งข้อมูลไปแสดง
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(Table_Screen data) //ส่งข้อมูลที่แก้ไขแล้วเข้ามา
        {
            ViewBag.S_CinemaID = new SelectList(db.Table_Cinema, "C_CinemaID", "C_Name", data.S_ScreenID);
            ViewBag.S_MovieID = new SelectList(db.Table_Movie, "M_MovieID", "M_NameMovie", data.S_MovieID);


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
                var CK = db.Table_Chair.Where(a => a.C_ScreenID == id)
                    .ToList(); //ค้นหาข้อมูลว่า idหนังถูกให้งานหรือป่าว
                if (CK.Count == 0) //==0แสดงว่าไม่ถูกใช้ลบได้
                {
                    var data = db.Table_Screen.Where(b => b.S_ScreenID == id)
                        .FirstOrDefault(); //ค้นหาข้อมูลเพียงค่าเดียวเพื่อแก้ไข
                    db.Table_Screen.Remove(data); // ลบข้อมูล
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