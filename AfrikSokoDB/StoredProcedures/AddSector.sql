CREATE PROCEDURE [dbo].[AddSector]
	@secname VARCHAR(250)
AS
BEGIN
	INSERT INTO Sector (SectorName) VALUES (@secname)
END