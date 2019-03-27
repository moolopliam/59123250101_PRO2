using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class CinemaOnController : Controller
    {
        private readonly Cinema5927Entities db = new Cinema5927Entities();

        // GET: CinemaOn
        public ActionResult Index(int CHK = 0)
        {
            TempData["CHK"] = 0;
            if (CHK != 0) TempData["CHK"] = CHK;
            var data = db.Table_Cinema.ToList();
            return View(data);
        }

        // GET: CinemaOn/Details/5
        public ActionResult Details(int id)
        {
            var data = db.Table_Cinema.Where(b => b.C_CinemaID == id)
                .FirstOrDefault();
            return View(data);
        }

        // GET: CinemaOn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CinemaOn/Create
        [HttpPost]
        public ActionResult Create(Table_Cinema data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    data.C_AmoutHire = 120;
                    db.Table_Cinema.Add(data);
                    db.SaveChanges();
                    return RedirectToAction("Index", new {CHK = 1});
                }
                // TODO: Add insert logic here

                return View(data);
            }
            catch
            {
                return View(data);
            }
        }

        // GET: CinemaOn/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.Table_Cinema.Where(b => b.C_CinemaID == id)
                .FirstOrDefault(); //ค้นหาข้อมูลเพียงค่าเดียวเพื่อแก้ไข
            return View(data);
        }

        // POST: CinemaOn/Edit/5
        [HttpPost]
        public ActionResult Edit(Table_Cinema data)
        {
            try
            {
                if (ModelState.IsValid) //เช็ดข้อมูล
                {
                    db.Entry(data).State = EntityState.Modified; //แก้ไขข้อมูล
                    db.SaveChanges(); //บันทึก
                    return RedirectToAction("Index", new {CHK = 4}); //ไปหน้า index
                }

                return View(data);
            }
            catch
            {
                return View(data);
            }
        }


        public ActionResult Delete(int id) //รับ PK เข้ามาเพื่อค้นข้อมูล
        {
            try
            {
                var CK = db.Table_Screen.Where(a => a.S_CinemaID == id)
                    .ToList(); //ค้นหาข้อมูลว่า idหนังถูกให้งานหรือป่าว
                if (CK.Count == 0) //==0แสดงว่าไม่ถูกใช้ลบได้
                {
                    var data = db.Table_Cinema.Where(b => b.C_CinemaID == id)
                        .FirstOrDefault(); //ค้นหาข้อมูลเพียงค่าเดียวเพื่อแก้ไข
                    db.Table_Cinema.Remove(data); // ลบข้อมูล
                    db.SaveChanges(); //บันทึก
                    return RedirectToAction(nameof(Index), new { CHK = 2 }); //ไปหน้า index
                }

                return RedirectToAction(nameof(Index), new { CHK = 3 }); //ไปหน้า index
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

