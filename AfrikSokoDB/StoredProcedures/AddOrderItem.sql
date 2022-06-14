CREATE PROCEDURE [dbo].[AddOrderItem]
	@orderid INT ,
	@prodid INT,
	@prodtypeid INT,
	@qty INT,
	@totprice DECIMAL(18,2)

AS
	BEGIN
		INSERT INTO OrderItems (OrderId, ProductId, ProductTypeId, Quantity, TotalPrice)
		VALUES (@orderid, @prodid, @prodtypeid, @qty, @totprice)
	END

