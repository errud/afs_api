CREATE PROCEDURE [dbo].[UpdateAddress]
	@userid INT,
	@street VARCHAR(200),
	@city VARCHAR(30),
	@state VARCHAR(30),
	@zipc VARCHAR(10),
	@ctry VARCHAR(20),
	@id INT
AS
BEGIN
	UPDATE Addresses SET UserId = @userid, Street = @street, City = @city, [State] = @state, Zip = @zipc, Country = @ctry
	WHERE Id = @id 
END