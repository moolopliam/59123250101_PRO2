using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return Redirect("~/ReportsR/WebFormMovie.aspx");
        }

        public ActionResult Index1()
        {
            return Redirect("~/ReportsR/WebFormOder.aspx");
        }

        public ActionResult Index2()
        {
            return Redirect("~/ReportsR/WebFormUnpaidOder.aspx");
        }
    }
}