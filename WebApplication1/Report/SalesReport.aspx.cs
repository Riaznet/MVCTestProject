using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Class;

namespace WebApplication1.Report
{
    public partial class SalesReport : System.Web.UI.Page
    {
        MyFunction func; 
        public SalesReport()
        {
            func = MyFunction.GetInstance(); 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string mobile = Session["Mobile"].ToString();
            GetData(mobile);
        }
        private void GetData(string Mobile)
        {
            DataSet ds = new DataSet();
            ds = func.DataSetData($"spGetSalesReport '{Mobile}'");
            RVSalesReport.ProcessingMode = ProcessingMode.Local;
            RVSalesReport.LocalReport.ReportPath = Server.MapPath("/report/salesReport.rdlc");
            ReportDataSource datasource = new ReportDataSource("dsSalesReport", ds.Tables[0]);
            this.RVSalesReport.LocalReport.DataSources.Clear();
            this.RVSalesReport.LocalReport.DataSources.Add(datasource);
        }
    }
}