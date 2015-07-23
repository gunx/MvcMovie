using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        //private List<TestInfo> GetList()
        private DataTable GetList()
        {
            List<TestInfo> list = new List<TestInfo>();
            string sql = @"select DataColumn1=a.实际标识, DataColumn2=s.名称
                            from TAmbulance a
                            left join TStation s on a.分站编码=s.编码 where a.车辆编码<'99998'";
            DataTable dt = SqlHelper.ExecuteDataSet(SqlHelper.MainConnectionString, CommandType.Text, sql, null).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                TestInfo ti = new TestInfo();
                //ti.DataColumn1 = dr["分站名称"].ToString();
                //ti.DataColumn2 = dr["实际标识"].ToString();
                list.Add(ti);
            }

            return dt;
        }

        public ActionResult Index(string type = "PDF")
        {
            //List<TestInfo> list = GetList();
            DataTable list = GetList();
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report/Report1.rdlc");


            ReportDataSource reportDataSource2 = new ReportDataSource("DataSet2", list);
            localReport.DataSources.Add(reportDataSource2);
            string reportType = type;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =
                "<DeviceInfo>" +
                "<OutPutFormat>" + type + "</OutPutFormat>" +
                "<PageWidth>11in</PageWidth>" +
                "<PageHeight>11in</PageHeight>" +
                "<MarginTop>0.5in</MarginTop>" +
                "<MarginLeft>1in</MarginLeft>" +
                "<MarginRight>1in</MarginRight>" +
                "<MarginBottom>0.5in</MarginBottom>" +
                "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            localReport.ReportEmbeddedResource = null;
            renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings
                );
            return File(renderedBytes, mimeType);
            //return View();
        }

        public ActionResult Index2(string type = "PDF")
        {
            AppDBDataSetTableAdapters.Print_PatientRecord_JijiuTableAdapter ada = new AppDBDataSetTableAdapters.Print_PatientRecord_JijiuTableAdapter();
            
            AppDBDataSet.Print_PatientRecord_JijiuDataTable dt = ada.GetData("2012102023511100100101", 1);
            
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report/PrintPatient.rdlc");


            ReportDataSource reportDataSource2 = new ReportDataSource("DataSet1", dt.AsEnumerable());
            localReport.DataSources.Add(reportDataSource2);
            string reportType = type;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =
                "<DeviceInfo>" +
                "<OutPutFormat>" + type + "</OutPutFormat>" +
                "<PageWidth>21cm</PageWidth>" +
                "<PageHeight>29.7cm</PageHeight>" +
                "<MarginTop>0.1cm</MarginTop>" +
                "<MarginLeft>0.5cm</MarginLeft>" +
                "<MarginRight>0.5cm</MarginRight>" +
                "<MarginBottom>0.1cm</MarginBottom>" +
                "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            localReport.ReportEmbeddedResource = null;
            renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings
                );
            return File(renderedBytes, mimeType);
        }

        public ActionResult Index3(string type = "PDF")
        {
            //DataSetReportTableAdapters.TDictionaryTableAdapter adapter = new DataSetReportTableAdapters.TDictionaryTableAdapter();
            DataSetReportTableAdapters.GetDictionaryTableAdapter adapter = new DataSetReportTableAdapters.GetDictionaryTableAdapter();
            //DataSetReport.TDictionaryDataTable dt = adapter.GetData("BanCi");
            DataSetReport.GetDictionaryDataTable dt = adapter.GetData("BanCi",3);

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report/Report2.rdlc");


            ReportDataSource reportDataSource2 = new ReportDataSource("DataSet1", dt.AsEnumerable());
            localReport.DataSources.Add(reportDataSource2);

            string reportType = type;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =
                "<DeviceInfo>" +
                "<OutPutFormat>" + type + "</OutPutFormat>" +
                "<PageWidth>21cm</PageWidth>" +
                "<PageHeight>29.7cm</PageHeight>" +
                "<MarginTop>0.1cm</MarginTop>" +
                "<MarginLeft>0.5cm</MarginLeft>" +
                "<MarginRight>0.5cm</MarginRight>" +
                "<MarginBottom>0.1cm</MarginBottom>" +
                "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            localReport.ReportEmbeddedResource = null;
            renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings
                );
            return File(renderedBytes, mimeType);
        }

        public void Index4()
        {
            //string aspx = "/AspNets/WebForm1.aspx";
            //using (var sw = new StringWriter())
            //{
            //    System.Web.HttpContext.Current.Server.Execute(aspx, sw, true);
            //    return Content(sw.ToString());
            //}
            Response.Redirect("~/AspNets/WebForm1.aspx");
        }
    }

    public class TestInfo
    {
        public string DataColumn1 {get; set;}
        public string DataColumn2 {get; set;}
    }
}
