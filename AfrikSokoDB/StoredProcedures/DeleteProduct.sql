CREATE PROCEDURE [dbo].[DeleteProduct]
	@id INT
AS
BEGIN
	DELETE FROM Product WHERE Id = @id
END
