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
    public partial class WebFormUnpaidOder : System.Web.UI.Page
    {
        private readonly Cinema5927Entities db = new Cinema5927Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var data = db.View_SumOder.OrderBy(a => a.U_Name).ToList(); // Read data from file

                var rd = new ReportDataSource("DataSet1", data); // binding datatable
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReportsR/ReportUnpaidOder.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rd);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var box = DropDownList1.SelectedValue;

            var data = db.View_SumOder.OrderBy(a => a.U_Name).ToList(); // Read data from file
            if (!String.IsNullOrEmpty(box))
            {
                data = db.View_SumOder.Where(a => a.B_Name.Contains(box)).ToList();
            }

            var rd = new ReportDataSource("DataSet1", data); // binding datatable
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReportsR/ReportUnpaidOder.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rd);
        }
    }
}