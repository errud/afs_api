CREATE PROCEDURE [dbo].[DeleteProductVariant]
	@prodid INT,
	@prodtypeid INT
AS
BEGIN
	DELETE FROM ProductVariant WHERE ProductId = @prodid and ProductTypeId = @prodtypeid
END
