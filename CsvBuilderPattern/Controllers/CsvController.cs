using CsvBuilderPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace CsvBuilderPattern.Controllers
{
    public class CsvController : Controller
    {
            

        private List<ErrorRecord> rec;
        string file_path = HostingEnvironment.MapPath("~/Folder/eror.csv");
        private CsvWorking<ErrorRecord> working;



        public CsvController()
        {
            var builder = new CsvBuilder();
            working = new CsvWorking<ErrorRecord>(builder);//initialize the working class
            rec = working.GetRecords(file_path);//initialze the GetRecord method
        }

        public ActionResult Show()
        {
            return View(rec);
        }
        public ActionResult Edit(string errCode)
        {
            var rec1 = rec.Find(e => e.errorCode == errCode);
            //var rec1 = rec.FirstOrDefault(r => r.errorCode == errCode.ToList()[0]);
            return View(rec1);
        }

        [HttpPost]
        public ActionResult Edit(ErrorRecord newVal)
        {
            ErrorRecord Oldval = rec.FirstOrDefault(r => r.errorCode == newVal.errorCode);
            if (Oldval != null)
            {
                Oldval.errorMessage = newVal.errorMessage;
                Oldval.TransactionDate = newVal.TransactionDate;
                //if (newVal.TransactionDate == default(DateTime))
                //{
                //    Oldval.TransactionDate = DateTime.Now;
                //}
                //else
                //{
                //    Oldval.TransactionDate = newVal.TransactionDate;
                //}





            }
            System.IO.File.WriteAllLines(file_path, new[] { "errorCode,errorMessage,TransactionDate" }.Concat(rec.Select(r => $"{r.errorCode},{r.errorMessage},{r.TransactionDate:MM/dd/yyyy HH:mm:ss}")));
            return View("Show", rec);
        }

        //public FileResult Download()
        //{
        //    var records = new List<ErrorRecord>();
        //    var data = System.IO.File.ReadAllBytes(file_path);

        //    return File(data,"text/csv","Update_error.csv");
        //}

        public FileResult DownloadCsv()
        {
            var csv = "errorCode,errorMessage,TransactionDate\n" +
                      string.Join("\n", rec.Select(r =>
                          $"{r.errorCode},{r.errorMessage},{r.TransactionDate:MM/dd/yyyy HH:mm:ss}"));

            byte[] data = System.Text.Encoding.UTF8.GetBytes(csv);
            return File(data, "text/csv", "Errors.csv");
        }

    }

}
