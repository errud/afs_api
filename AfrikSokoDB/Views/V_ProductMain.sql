CREATE VIEW [dbo].[V_ProductMain]
	AS SELECT s.Company, a.FirstName, a.LastName,  p.Title, p.[Description], p.ImageUrl, p.Origin, c.[Name] as Categories, pt.[Name] as ProductType, si.Quantity, si.TotalPrice, a.Id as [Uid]
	FROM Product p join SupplyItems si ON si.ProductId = p.Id join AppUser a ON a.Id = si.UserId join ProductType pt ON pt.Id = si.ProductTypeId join Category c ON c.Id = p.CategoryId join Supplier s ON s.UserId = a.Id
