CREATE PROCEDURE [dbo].[DeleteCategory]
	@id INT
AS
BEGIN
	DELETE FROM Category WHERE Id = @id
END