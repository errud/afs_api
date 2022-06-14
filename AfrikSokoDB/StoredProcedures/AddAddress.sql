CREATE PROCEDURE [dbo].[AddAddress]
	@userid INT,
	@street VARCHAR(200),
	@city VARCHAR(30),
	@state VARCHAR(30),
	@zipc VARCHAR(10),
	@ctry VARCHAR(20)
AS
	BEGIN
		INSERT INTO Addresses (UserId, Street, City, [State], Zip, Country)
		VALUES (@userid, @street, @city, @state, @zipc, @ctry)
	END

