CREATE TABLE [dbo].[Supplier]
(
	[Id] INT NOT NULL IDENTITY,
    [UserId] INT NOT NULL,
    [Company] VARCHAR(80) NULL,
    [Logo] VARCHAR(MAX) NULL,
    [SectorId] INT NOT NULL, 
    [ServiceId] INT NOT NULL, 
    [Membership] BIT NOT NULL DEFAULT (0), 
    [Contact] VARCHAR(100) NOT NULL, 
    [Phone] VARCHAR(100) NOT NULL, 
    [Email] VARCHAR(100) NOT NULL, 
    [Url] VARCHAR(50) NULL, 
    [Address] VARCHAR(250) NULL, 
    [City] VARCHAR(80) NOT NULL, 
    [Country] VARCHAR(50) NOT NULL,
    [AdditInfo] VARCHAR(350) NULL, 
    [Status] BIT NOT NULL DEFAULT (1),
    [Created] DATETIME2 NOT NULL 

    CONSTRAINT [PK_Supplier] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Supplier_User] UNIQUE (UserId),
    CONSTRAINT FK_Supplier_User FOREIGN KEY (UserId) REFERENCES AppUser(Id),
    CONSTRAINT FK_Supplier_Sector FOREIGN KEY (SectorId) REFERENCES Sector(Id),
    CONSTRAINT FK_Supplier_Service FOREIGN KEY (ServiceId) REFERENCES ServiceAsked(Id),
    CONSTRAINT [UQ_Supplier_Company] UNIQUE (Company)

)
