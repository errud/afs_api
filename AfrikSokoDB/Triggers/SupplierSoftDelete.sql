CREATE TRIGGER [SupplierSoftDelete]
ON [dbo].[Supplier]
INSTEAD OF DELETE
AS
BEGIN
	UPDATE [Supplier] SET [Status] = 0 WHERE Id = (SELECT Id FROM deleted)
END
