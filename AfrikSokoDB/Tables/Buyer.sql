CREATE TABLE [dbo].[Buyer]
(
	[Id] INT NOT NULL IDENTITY, 
    [UserId] INT NOT NULL,
    [Phone] VARCHAR(80) NOT NULL,
    [City] VARCHAR(50) NOT NULL, 
    [Country] VARCHAR(50) NOT NULL, 
    [Company] VARCHAR(80) NOT NULL, 
    [Url] VARCHAR(80) NOT NULL,
    [Status] BIT NOT NULL DEFAULT (1)
    CONSTRAINT [PK_Buyer] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Buyer_User] UNIQUE (UserId),
    CONSTRAINT FK_Buyer_User FOREIGN KEY (UserId) REFERENCES AppUser(Id)

)
