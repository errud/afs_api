CREATE TABLE [dbo].[ProductVariant]
(
	[ProductId] INT NOT NULL, 
    [ProductTypeId] INT NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL, 
    [OriginalPrice] DECIMAL(18, 2) NOT NULL, 
    [Visible] BIT NOT NULL DEFAULT (1),
    [Deleted] BIT NOT NULL DEFAULT (0)
    CONSTRAINT FK_ProdVariant_Product FOREIGN KEY (ProductId) REFERENCES Product(Id),
    CONSTRAINT FK_ProdVariant_ProdType FOREIGN KEY (ProductTypeId) REFERENCES ProductType(Id)

)
