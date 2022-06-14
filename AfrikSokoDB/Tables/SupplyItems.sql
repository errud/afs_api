CREATE TABLE [dbo].[SupplyItems]
(
	[UserId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [ProductTypeId] INT NOT NULL, 
    [Quantity] INT NOT NULL,
    [TotalPrice] DECIMAL(18, 2) NOT NULL,    
    [PostedDate] DATETIME2 NOT NULL DEFAULT GetDate()
    CONSTRAINT FK_SupplyItems_AppUser FOREIGN KEY (UserId) REFERENCES AppUser(Id),
    CONSTRAINT FK_SupplyItems_Product FOREIGN KEY (ProductId) REFERENCES Product(Id),
    CONSTRAINT FK_SupplyItems_ProdType FOREIGN KEY (ProductTypeId) REFERENCES ProductType(Id)
)
