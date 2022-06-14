CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL IDENTITY, 
    [Name] VARCHAR(100) NOT NULL, 
    [Url] VARCHAR(30) NOT NULL,
    [Deleted] BIT NOT NULL DEFAULT (0),
    [Visible] BIT NOT NULL DEFAULT (1)
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
)
