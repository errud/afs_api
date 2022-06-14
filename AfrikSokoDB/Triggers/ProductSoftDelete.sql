CREATE TRIGGER [ProductSoftDelete]
ON [dbo].[Product]
INSTEAD OF DELETE
AS
BEGIN
	UPDATE [Product] SET Deleted = 1 WHERE Id = (SELECT Id FROM deleted)
END
