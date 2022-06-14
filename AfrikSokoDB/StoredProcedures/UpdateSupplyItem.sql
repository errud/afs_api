CREATE PROCEDURE [dbo].[UpdateSupplyItem]
	@userid INT,
	@prodid INT,
	@prodtypeid INT,
	@qty INT,
	@totprice DECIMAL(18,2)

AS
BEGIN
	UPDATE SupplyItems SET ProductId = @prodid, ProductTypeId = @prodtypeid, Quantity = @qty, TotalPrice = @totprice
	WHERE UserId = @userid
END

