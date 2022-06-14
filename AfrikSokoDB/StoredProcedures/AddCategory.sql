CREATE PROCEDURE [dbo].[AddCategory]
	@name VARCHAR(100),
	@url VARCHAR(30)

AS
	BEGIN
		INSERT INTO Category ([Name], [Url], [Deleted], [Visible])
		VALUES (@name, @url, 0, 1)
	END


