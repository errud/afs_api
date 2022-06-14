CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL IDENTITY,
    [Title] VARCHAR(MAX) NULL,
    [ImageUrl] VARCHAR(MAX) NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [Origin] VARCHAR(50) NULL,
    [CategoryId] INT NOT NULL,
    [Featured] BIT NOT NULL DEFAULT (0),
    [Deleted] BIT NOT NULL DEFAULT (0),
    [Visible] BIT NOT NULL DEFAULT (1)
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
    CONSTRAINT FK_Product_Category FOREIGN KEY (CategoryId) REFERENCES Category(Id)
)
