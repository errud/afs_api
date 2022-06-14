CREATE PROCEDURE [dbo].[UpdateBuyer]
	@userid INT,
	@tel VARCHAR(80),
	@city VARCHAR(50),
	@ctry VARCHAR(50),
	@company VARCHAR(80),
	@url VARCHAR(80),
	@id INT
AS
BEGIN
	UPDATE Buyer SET UserId = @userid, Phone = @tel, City = @city, Country = @ctry, Company = @company, [Url] = @url, [Status] = 1
	WHERE Id = @id
END
