CREATE PROCEDURE [dbo].[AddSupplier]
    @userid INT,
	@company VARCHAR(80),
	@logo VARCHAR(MAX),
	@secId INT,
	@serId INT,
	@contact VARCHAR(100),
	@phone VARCHAR(100),
	@email VARCHAR(100),
	@url VARCHAR(50),
	@address VARCHAR(250),
	@city VARCHAR(80),
	@ctry VARCHAR (50),
	@ainfo VARCHAR(350)

AS
	BEGIN
		INSERT INTO Supplier (UserId, Company, Logo, SectorId, ServiceId, Membership, Contact, Phone, Email, [Url], [Address], City, Country, AdditInfo, [Status], Created) 
		VALUES (@userid, @company, @logo, @secId, @serId, 0, @contact, @phone, @email, @url, @address, @city, @ctry, @ainfo, 1, GetDate())
	END