using Cinema.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema.Reports
{
    public partial class WebFormOder : System.Web.UI.Page
    {
        private readonly Cinema5927Entities db = new Cinema5927Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                var data = db.ViewOders.OrderBy(a => a.U_Name).ToList(); // Read data from file

                var rd = new ReportDataSource("DataSet1", data); // binding datatable
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReportsR/ReportOder.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rd);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var box = TextBox1.Text;
            var box1 = TextBox2.Text;

            var data = db.ViewOders.OrderBy(a => a.U_Name).ToList();

            if (!String.IsNullOrEmpty(box)&&!String.IsNullOrEmpty(box1))
            {
                data = db.ViewOders.Where(a => a.U_Name.Contains(box) && a.O_DateOder.Contains(box1)).ToList();
            }

            else if (!String.IsNullOrEmpty(box))
            {
                data = db.ViewOders.
                    Where(z => z.U_Name.Contains(box)).ToList();
            }
            else if (!String.IsNullOrEmpty(box1))
            {
                data = db.ViewOders.
                    Where(z => z.O_DateOder.Contains(box1)).ToList();
            }

            var rd = new ReportDataSource("DataSet1", data); // binding datatable
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReportsR/ReportOder.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rd);
        }
    }
}