﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Exporting_and_Printing_a_Report_from_Code.Models;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;
using System.Data;

namespace Exporting_and_Printing_a_Report_from_Code.Controllers
{
    public class HomeController : Controller
    {
        static HomeController()
        {
            // How to Activate
            //Stimulsoft.Base.StiLicense.Key = "6vJhGtLLLz2GNviWmUTrhSqnO...";
            //Stimulsoft.Base.StiLicense.LoadFromFile("license.key");
            //Stimulsoft.Base.StiLicense.LoadFromStream(stream);
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private StiReport GetReport()
        {
            var reportPath = StiNetCoreHelper.MapPath(this, "Reports/TwoSimpleLists.mrt");
            var report = new StiReport();
            report.Load(reportPath);

            return report;
        }

        public IActionResult PrintPdf()
        {
            var report = this.GetReport();
            return StiNetCoreReportResponse.PrintAsPdf(report);
        }

        public IActionResult PrintHtml()
        {
            var report = this.GetReport();
            return StiNetCoreReportResponse.PrintAsHtml(report);
        }

        public IActionResult ExportPdf()
        {
            var report = this.GetReport();
            return StiNetCoreReportResponse.ResponseAsPdf(report);
        }

        public IActionResult ExportHtml()
        {
            var report = this.GetReport();
            return StiNetCoreReportResponse.ResponseAsHtml(report);
        }

        public IActionResult ExportXls()
        {
            var report = this.GetReport();
            return StiNetCoreReportResponse.ResponseAsXls(report);
        }
    }
}
