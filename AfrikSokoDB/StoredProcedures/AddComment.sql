CREATE PROCEDURE [dbo].[AddComment]
	@userid INT,
	@prodid INT,
	@note VARCHAR(MAX)


AS
	BEGIN
		INSERT INTO Comments (UserId, ProductId, Content, Created)
		VALUES (@userid, @prodid, @note, GetDate())
	END

