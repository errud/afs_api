CREATE PROCEDURE [dbo].[UpdateProduct]
	@title VARCHAR(MAX),
	@imgurl VARCHAR(MAX),
	@descr VARCHAR(MAX),
	@origin VARCHAR(50),
	@catid INT,
	@id INT
AS
BEGIN
	UPDATE Product SET Title = @title, ImageUrl = @imgurl, [Description] = @descr, Origin = @origin, CategoryId = @catid
	WHERE Id = @id
END
