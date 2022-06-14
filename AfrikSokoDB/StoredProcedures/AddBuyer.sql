CREATE PROCEDURE [dbo].[AddBuyer]
	@userid INT,
	@tel VARCHAR(80),
	@city VARCHAR(50),
	@ctry VARCHAR(50),
	@company VARCHAR(80),
	@url VARCHAR(80)
AS
	BEGIN
		INSERT INTO Buyer (UserId, Phone, City, Country, Company, [Url], [Status])
		VALUES (@userid, @tel, @city, @ctry, @company, @url, 1)
	END

