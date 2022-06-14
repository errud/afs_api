CREATE PROCEDURE [dbo].[AddProductVariant]
	@prodid INT,
	@prodtypeid INT,
	@price DECIMAL(18,2),
	@origprice DECIMAL(18,2)


AS
	BEGIN
		INSERT INTO ProductVariant (ProductId, ProductTypeId, Price, OriginalPrice)
		VALUES (@prodid, @prodtypeid, @price, @origprice)
	END
