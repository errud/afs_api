CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL IDENTITY, 
    [UserId] INT NOT NULL, 
    [OrderDate] DATETIME2 NOT NULL , 
    [TotalPrice] DECIMAL(18, 2) NOT NULL
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT FK_Orders_AppUser FOREIGN KEY (UserId) REFERENCES AppUser(Id)


)
