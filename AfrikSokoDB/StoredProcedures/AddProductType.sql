CREATE PROCEDURE [dbo].[AddProductType]
	@name VARCHAR(100)

AS
	BEGIN
		INSERT INTO ProductType ([Name])
		VALUES (@name)
	END
