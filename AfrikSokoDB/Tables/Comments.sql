CREATE TABLE [dbo].[Comments]
(
	[Id] INT NOT NULL IDENTITY,
	[UserId] INT NULL,
	[ProductId] INT NULL, 
    [Content] VARCHAR(MAX) NOT NULL, 
    [Created] DATETIME2 NOT NULL 
    CONSTRAINT [PK_Comments] PRIMARY KEY ([Id]),
    CONSTRAINT FK_Comments_User FOREIGN KEY (UserId) REFERENCES AppUser(Id)
    
)
