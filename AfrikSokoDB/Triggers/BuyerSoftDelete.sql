CREATE TRIGGER [BuyerSoftDelete]
ON [dbo].[Buyer]
INSTEAD OF DELETE
AS
BEGIN
	UPDATE [Buyer] SET [Status] = 0 WHERE Id = (SELECT Id FROM deleted)
END
