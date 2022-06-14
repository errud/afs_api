CREATE PROCEDURE [dbo].[DeleteAddress]
	@id INT
AS
BEGIN
	DELETE FROM Addresses WHERE Id = @id
END
