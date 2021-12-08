using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SalesItem
    {
        //Composite key InvoiceNo, ItemId
        [Key]
        [Column(Order = 1)]
        [MaxLength(6)]
        [ForeignKey("Sale")]
        public string InvoiceNo { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("StockItem")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public long ItemId { get; set; }
        public decimal Qty { get; set; }
        public decimal SalesPrice { get; set; }

        //Navigation properties
        public Sale Sale { get; set; }
        public StockItem StockItem { get; set; }


    }
}