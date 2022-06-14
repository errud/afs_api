CREATE TABLE [dbo].[CartItems]
(
	[UserId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [ProductTypeId] INT NOT NULL, 
    [Quantity] INT NOT NULL
    CONSTRAINT FK_CartItems_AppUser FOREIGN KEY (UserId) REFERENCES AppUser(Id),
    CONSTRAINT FK_CartItems_Product FOREIGN KEY (ProductId) REFERENCES Product(Id),
    CONSTRAINT FK_CartItems_ProdType FOREIGN KEY (ProductTypeId) REFERENCES ProductType(Id)

)
