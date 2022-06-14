CREATE PROCEDURE [dbo].[AddProduct]
	@title VARCHAR(MAX),
	@imgurl VARCHAR(MAX),
	@descr VARCHAR(MAX),
	@origin VARCHAR(50),
	@catid INT

AS
	BEGIN
		INSERT INTO Product (Title, ImageUrl, [Description], Origin, CategoryId)
		VALUES (@title, @imgurl, @descr, @origin, @catid)
	END

	