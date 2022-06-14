CREATE PROCEDURE [dbo].[DeleteSupplyItem]
	@userid INT,
	@prodid INT,
	@prodtypeid INT
AS
BEGIN
	DELETE FROM SupplyItems WHERE UserId = @userid and ProductId = @prodid and ProductTypeId = @prodtypeid
END

