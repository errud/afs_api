CREATE PROCEDURE [dbo].[UpdateProductVariant]
	@prodid INT,
	@prodtypeid INT,
	@price DECIMAL(18,2),
	@origiprice DECIMAL(18,2),
	@visible BIT

AS
BEGIN

	UPDATE ProductVariant SET ProductId = @prodid, ProductTypeId = @prodtypeid, Price = @price, OriginalPrice = @origiprice, Visible = @visible
	
END
