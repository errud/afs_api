CREATE TABLE [dbo].[FavoriteProductType]
(
	[Id] INT NOT NULL IDENTITY,
	[AppUserId] INT NULL,
    [ProdtypeId] INT NULL

	CONSTRAINT [PK_FavoriteProdType] PRIMARY KEY ([Id]),
	CONSTRAINT FK_FavoriteProdType_User FOREIGN KEY (AppUserId) REFERENCES AppUser(Id),
	CONSTRAINT FK_FavoriteProdType_ProductType FOREIGN KEY (ProdtypeId) REFERENCES ProductType(Id)
	
)
