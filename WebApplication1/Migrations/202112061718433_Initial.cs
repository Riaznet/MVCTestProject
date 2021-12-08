namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesItems",
                c => new
                    {
                        InvoiceNo = c.String(nullable: false, maxLength: 6),
                        ItemId = c.Long(nullable: false),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.InvoiceNo, t.ItemId })
                .ForeignKey("dbo.Sales", t => t.InvoiceNo, cascadeDelete: true)
                .ForeignKey("dbo.StockItems", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.InvoiceNo)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        InvoiceNo = c.String(nullable: false, maxLength: 6),
                        Date = c.DateTime(nullable: false),
                        CustomerMobile = c.String(maxLength: 11),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.InvoiceNo);
            
            CreateTable(
                "dbo.StockItems",
                c => new
                    {
                        ItemId = c.Long(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemName = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesItems", "ItemId", "dbo.StockItems");
            DropForeignKey("dbo.SalesItems", "InvoiceNo", "dbo.Sales");
            DropIndex("dbo.SalesItems", new[] { "ItemId" });
            DropIndex("dbo.SalesItems", new[] { "InvoiceNo" });
            DropTable("dbo.StockItems");
            DropTable("dbo.Sales");
            DropTable("dbo.SalesItems");
        }
    }
}
