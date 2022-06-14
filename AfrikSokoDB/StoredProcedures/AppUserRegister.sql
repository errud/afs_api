﻿CREATE PROCEDURE [dbo].[AppUserRegister]
	@email VARCHAR(50),
	@passwd VARCHAR(50),
	@fname VARCHAR(50),
	@lname VARCHAR(50),
	@nickname VARCHAR(50)

AS 
BEGIN
	SET NOCOUNT ON
	DECLARE @salt VARCHAR(100)
	SET @salt = CONCAT(NEWID(), NEWID(), NEWID())

	DECLARE @secret VARCHAR(100)
	SET @secret = dbo.GetSecretKey()

	DECLARE @hashpwd VARBINARY(64)
	SET @hashpwd = HASHBYTES('SHA2_512', CONCAT(@Salt, @passwd, @Salt, @secret));

	DECLARE @currentId INT

	INSERT INTO AppUser (Email, Passwd, FirstName, LastName, NickName, IsActive, Created) VALUES (@email, @hashpwd, @fname, @lname, @nickname, 1, GetDate())

	SELECT @currentId = Id FROM AppUser WHERE Email = @email

	INSERT INTO AppSalt (SaltValue, UserId) VALUES (@salt, @currentId)

	SELECT Id FROM AppUser WHERE Email = @email
END