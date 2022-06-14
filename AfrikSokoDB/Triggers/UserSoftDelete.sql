CREATE TRIGGER [UserSoftDelete]
ON [dbo].[AppUser]
INSTEAD OF DELETE
AS
BEGIN 
	UPDATE [AppUser] SET IsActive = 0 WHERE Id = (SELECT Id FROM deleted) 
END