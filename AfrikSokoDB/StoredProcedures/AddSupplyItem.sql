CREATE PROCEDURE [dbo].[AddSupplyItem]
	@userid INT ,
	@prodid INT,
	@prodtypeid INT,
	@qty INT,
	@totprice DECIMAL(18,2)

AS
	BEGIN
		INSERT INTO SupplyItems (UserId, ProductId, ProductTypeId, Quantity, TotalPrice)
		VALUES (@userid, @prodid, @prodtypeid, @qty, @totprice)
	END
