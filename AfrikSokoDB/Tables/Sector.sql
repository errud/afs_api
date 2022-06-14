CREATE TABLE [dbo].[Sector]
(
	[Id] INT NOT NULL IDENTITY, 
    [SectorName] VARCHAR(250) NOT NULL
	CONSTRAINT [PK_Sector] PRIMARY KEY ([Id]),
	CONSTRAINT [UK_Sector_SectorName] UNIQUE (SectorName) 
)
