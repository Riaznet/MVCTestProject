using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels
{
    public class SaleReportVm
    {
        public string InvoiceNo { get; set; }
        public DateTime Date { get; set; }
        public string ItemName { get; set; }

        public decimal SaleAmount { get; set; }
        public decimal PurchasePrice { get; set; }
        //public decimal Qty { get; set; }
        //public decimal PurchaseTotal { get; set; }

        public decimal Profit { get; set; }



    }
}