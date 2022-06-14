CREATE PROCEDURE [dbo].[DeleteComment]
	@id INT
AS
BEGIN
	DELETE FROM Comments WHERE Id = @id
END
