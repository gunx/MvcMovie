using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MvcMovie.AspNets
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Data_Binding();
            }
        }

        private void Data_Binding()
        {
            //DataSetReportTableAdapters.TDictionaryTableAdapter adapter = new DataSetReportTableAdapters.TDictionaryTableAdapter();
            
            //DataSetReport.TDictionaryDataTable dt = adapter.GetData("BanCi");

            //LocalReport localReport = new LocalReport();
            //localReport.ReportPath = Server.MapPath("~/Report/Report2.rdlc");

            List<NameAndCount> list = new List<NameAndCount>();
            NameAndCount nc1 = new NameAndCount();
            nc1.Name = "张三";
            nc1.SL = 34;
            NameAndCount nc2 = new NameAndCount();
            nc2.Name = "李四";
            nc2.SL = 55;
            NameAndCount nc3 = new NameAndCount();
            nc3.Name = "王五";
            nc3.SL = 88;

            list.Add(nc1);
            list.Add(nc2);
            list.Add(nc3);

            ReportDataSource reportDataSource2 = new ReportDataSource("DataSet3", list);
            //localReport.DataSources.Add(reportDataSource2);

            this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Report1.rdlc");
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.ReportViewer1.LocalReport.Refresh();
        }
    }

    class NameAndCount
    {
        public string Name {get;set;}
        public int SL { get; set; }
    }
}