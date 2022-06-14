CREATE TABLE [dbo].[OrderItems]
(
	[OrderId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [ProductTypeId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [TotalPrice] DECIMAL(18, 2) NOT NULL
    CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderId) REFERENCES Orders(Id),
    CONSTRAINT FK_OrderItems_Product FOREIGN KEY (ProductId) REFERENCES Product(Id),
    CONSTRAINT FK_OrderItems_ProdType FOREIGN KEY (ProductTypeId) REFERENCES ProductType(Id)
)
