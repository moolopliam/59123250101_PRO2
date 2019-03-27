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
    public partial class WebFormMovie : System.Web.UI.Page
    {
        private readonly Cinema5927Entities db = new Cinema5927Entities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                var data = db.ViewMovies.OrderBy(a => a.S_NameStatus).ToList(); // Read data from file

                var rd = new ReportDataSource("DataSet1", data); // binding datatable
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReportsR/ReportMovie.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rd);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var b = DropDownList1.SelectedValue;
            var x = TextBox1.Text;

            var data = db.ViewMovies.OrderBy(a => a.S_NameStatus).ToList();
            if (!String.IsNullOrEmpty(b) && !String.IsNullOrEmpty(x))
            {
                data = db.ViewMovies.Where(a => a.S_NameStatus == b && a.M_NameMovie.Contains(x)).ToList();
            }

            else if (!String.IsNullOrEmpty(b))
            { 
                data = db.ViewMovies.
                    Where(z => z.S_NameStatus == b).ToList();
            }
            else if (!String.IsNullOrEmpty(x))
            {
                data = db.ViewMovies.
                    Where(z => z.M_NameMovie.Contains(x)).ToList();
            }

            var rd = new ReportDataSource("DataSet1", data); // binding datatable
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ReportsR/ReportMovie.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rd);
        }


    }
}