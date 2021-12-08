using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Sale
    {
        //Primary Key
        [MaxLength(6)]
        [Key]
        public string InvoiceNo { get; set; }
        public DateTime Date { get; set; }

        [MaxLength(11)]

        public string CustomerMobile { get; set; }
        public decimal TotalAmount { get; set; }

        public ICollection<SalesItem> SaleItems { get; set; }



    }
}