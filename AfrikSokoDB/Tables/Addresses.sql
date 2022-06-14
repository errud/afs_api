CREATE TABLE [dbo].[Addresses]
(
	[Id] INT NOT NULL IDENTITY, 
    [UserId] INT NOT NULL, 
    [Street] VARCHAR(200) NULL, 
    [City] VARCHAR(30) NOT NULL, 
    [State] VARCHAR(30) NULL, 
    [Zip] VARCHAR(10) NULL, 
    [Country] VARCHAR(20) NOT NULL
    CONSTRAINT [PK_Address] PRIMARY KEY ([Id]),
    CONSTRAINT FK_Address_User FOREIGN KEY (UserId) REFERENCES AppUser(Id)
)
