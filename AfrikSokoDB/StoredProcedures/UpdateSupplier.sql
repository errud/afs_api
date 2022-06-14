CREATE PROCEDURE [dbo].[UpdateSupplier]
    @userid INT,
	@company VARCHAR(80),
	@logo VARCHAR(MAX),
	@secId INT,
	@serId INT,
    @member BIT,
	@contact VARCHAR(100),
	@phone VARCHAR(100),
	@email VARCHAR(100),
	@url VARCHAR(50),
	@address VARCHAR(250),
	@city VARCHAR(80),
	@ctry VARCHAR (50),
	@ainfo VARCHAR(350),
	@id INT
AS
BEGIN
	UPDATE Supplier SET UserId = @userid, Company = @company, Logo = @logo, SectorId = @secId, ServiceId = @serId, Membership = @member, Contact = @contact, Phone = @phone, Email = @email, [Url] = @url,  [Address] = @address, City = @city,	Country = @ctry, AdditInfo = @ainfo
	WHERE Id = @id
END

           