CREATE PROCEDURE [dbo].[UpdateCategory]
    @name VARCHAR(100),
	@url VARCHAR(30),
	@id INT

AS
	BEGIN
		UPDATE Category SET [Name] = @name, [Url] = @url
		WHERE Id = @id
	END
