CREATE TABLE [dbo].[ProductType]
(
	[Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(100) NOT NULL
    CONSTRAINT [PK_ProductType] PRIMARY KEY ([Id])
)
