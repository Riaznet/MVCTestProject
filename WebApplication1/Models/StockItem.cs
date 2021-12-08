using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class StockItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ItemId {get; set; }
        public decimal PurchasePrice { get; set; }
        [MaxLength(200, ErrorMessage = "Item Name Cannot Exceed 200 characters")]
        public string ItemName { get; set; }

        public ICollection<SalesItem> SaleItems { get; set; }

    }
}