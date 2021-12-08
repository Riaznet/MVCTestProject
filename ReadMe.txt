
1.hange the connection string from the web.config file.

2.open package manager console in vs and run the command to create the db schema.: 
Update-database


3.sql insert using ssms:
*************************
USE [StockDatabase]
GO
INSERT [dbo].[Sales] ([InvoiceNo], [Date], [CustomerMobile], [TotalAmount]) VALUES (N'INV001', CAST(N'2021-12-06 00:00:00.000' AS DateTime), N'01913966147', CAST(180000.00 AS Decimal(18, 2)))
INSERT [dbo].[Sales] ([InvoiceNo], [Date], [CustomerMobile], [TotalAmount]) VALUES (N'INV002', CAST(N'2021-12-06 00:00:00.000' AS DateTime), N'01923966147', CAST(55000.00 AS Decimal(18, 2)))
INSERT [dbo].[StockItems] ([ItemId], [PurchasePrice], [ItemName]) VALUES (1, CAST(150000.00 AS Decimal(18, 2)), N'Laptop')
INSERT [dbo].[StockItems] ([ItemId], [PurchasePrice], [ItemName]) VALUES (2, CAST(50000.00 AS Decimal(18, 2)), N'Mobile')
INSERT [dbo].[SalesItems] ([InvoiceNo], [ItemId], [Qty], [SalesPrice]) VALUES (N'INV001', 1, CAST(1.00 AS Decimal(18, 2)), CAST(180000.00 AS Decimal(18, 2)))
INSERT [dbo].[SalesItems] ([InvoiceNo], [ItemId], [Qty], [SalesPrice]) VALUES (N'INV002', 2, CAST(1.00 AS Decimal(18, 2)), CAST(55000.00 AS Decimal(18, 2)))
 
4.Create procedure
*********************
USE [StockDatabase]
GO
/****** Object:  StoredProcedure [dbo].[spGetSalesReport]    Script Date: 12/07/2021 6:18:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetSalesReport] 
@MobileNo nvarchar(11)
as
Begin 
SELECT        Sales.InvoiceNo, Sales.Date, StockItems.ItemName, SalesItems.SalesPrice, StockItems.PurchasePrice,SalesItems.SalesPrice-StockItems.PurchasePrice Profit
FROM            Sales INNER JOIN
                         SalesItems ON Sales.InvoiceNo = SalesItems.InvoiceNo INNER JOIN
                         StockItems ON SalesItems.ItemId = StockItems.ItemId Where Sales.CustomerMobile=@MobileNo
end



run the project.
