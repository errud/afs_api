CREATE TRIGGER [CategorySoftDelete]
ON [dbo].[Category]
INSTEAD OF DELETE
AS
BEGIN
	UPDATE [Category] SET Deleted = 1 WHERE Id = (SELECT Id FROM deleted)
END
