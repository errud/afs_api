﻿CREATE PROCEDURE [dbo].[DeleteBuyer]
	@id INT
AS
BEGIN
	DELETE FROM Buyer WHERE Id = @id
END
