CREATE VIEW [dbo].[V_FavoriteProdType]
	AS SELECT p.Id as Id, p.Name as Name, f.AppUserId as 'uid' FROM ProductType p 
	JOIN FavoriteProductType f ON p.Id = f.ProdtypeId
