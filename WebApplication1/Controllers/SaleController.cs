using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class SaleController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Sale
        [HttpGet]
        public ActionResult UI()
        {
            TempData["vm"] = null;

            return View();
        }

        [HttpPost]
        public ActionResult UI(SaleReportUi vm)
        {
            TempData["vm"] = vm;
            if (vm.CustomerMobile != null)
                return RedirectToAction("Report");
            else
                return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        [HttpPost]
        public ActionResult UIRdlc(SaleReportUi vm)
        {
            Session["Mobile"] = vm.CustomerMobile;
            if (vm.CustomerMobile != null)
                return RedirectToAction("../Report/SalesReport.aspx");
            else
                return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        [HttpGet]
        public ActionResult Report()
        {

            SaleReportUi vm = new SaleReportUi();
            if (TempData["vm"] != null) vm = (SaleReportUi)TempData["vm"];
            ICollection<Sale> Sales = db.Sales.ToList();
            ICollection<SalesItem> SalesItems = db.SaleItems.ToList();
            ICollection<StockItem> StockItems = db.StockItems.ToList();

            ICollection<SaleReportVm> saleReportVMList =
                (from s in Sales
                 join sli in SalesItems on s.InvoiceNo equals sli.InvoiceNo
                 join si in StockItems on sli.ItemId equals si.ItemId
                 where s.CustomerMobile == vm.CustomerMobile
                 select new SaleReportVm()
                 {
                     InvoiceNo = s.InvoiceNo,
                     Date = s.Date,
                     ItemName = si.ItemName,
                     SaleAmount = s.TotalAmount,
                     PurchasePrice = si.PurchasePrice,
                     Profit = s.TotalAmount - (si.PurchasePrice * sli.Qty)
                 }).ToList();
            return View(saleReportVMList);
        }
    }
}