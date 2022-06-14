CREATE PROCEDURE [dbo].[UpdateComment]
	@userid INT,
	@prodid INT,
	@note VARCHAR(MAX),
	@id INT
AS
	
	BEGIN
		UPDATE Comments SET [UserId] = @userid, ProductId = @prodid, Content = @note, Created = Getdate()
		WHERE Id = @id
	END
