CREATE PROCEDURE [dbo].[DeleteSupplier]
	@id INT
AS
BEGIN
	DELETE FROM Supplier WHERE Id = @id
END
