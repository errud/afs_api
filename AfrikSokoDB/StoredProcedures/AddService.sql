CREATE PROCEDURE [dbo].[AddService]
	@servname VARCHAR(250),
	@price DECIMAL(18,2),
	@period VARCHAR(50),
	@note VARCHAR(80)
AS
BEGIN
	INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES (@servname, @price, @period, @note)
END