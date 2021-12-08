using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DataContext: DbContext 
    {
        public DataContext() : base("name=MyConnection")
        {
            
        }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SalesItem> SaleItems { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
    }
}