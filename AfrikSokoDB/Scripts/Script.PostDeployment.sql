/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO AppRole (RoleName) VALUES ('User'), ('Moderator'), ('Admin')

EXEC AppUserRegister 'admin@afriksoko.com', 'Test1234=', 'Eric', 'Rudasingwa', 'Eric'
EXEC AppUserRegister 'moderator@afriksoko.com', 'Modo1234=', 'Olivier', 'Kamanzi', 'Moderator'
EXEC AppUserRegister 'user@afriksoko.com', 'User1234=', 'Daniel', 'Sowah', 'User'
EXEC AppUserRegister 'kolotoure@wakandaplc.com', 'koto1234=','Kolo', 'Touré', 'Ktouré'
EXEC AppUserRegister 'vkompany@mail.com', 'vko1234=', 'Vincent', 'Kompany', 'Vkompany'
EXEC AppUserRegister 'kdebruyne@mail.com', 'kdb1234=', 'Kevin', 'De Bruyne', 'Kdbruyne'


UPDATE AppUser SET RoleId = 3 WHERE Id = 1
UPDATE AppUser SET RoleId = 2 WHERE Id = 2

INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Basic Membership',500.00, 'monthly','Save 25% annually')
INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Full Membership',500.00, 'monthly','Save 25% annually')
INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Management & Advisory',1500.00, 'monthly','Save 25% annually')
INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Management',700.00, 'monthly','Save 25% annually')
INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Management Plus',1000.00, 'monthly','Save 25% annually')
INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Advisory',200.00, 'monthly','Save 25% annually')
INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Advisory Plus',400.00, 'monthly','Save 25% annually')
INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Financing',5500.00, 'monthly','Save 25% annually')
INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Financing Plus',6500.00, 'monthly','Save 25% annually')
INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Certification',300.00, 'monthly','Save 25% annually')
INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Certification Plus',500.00, 'monthly','Save 25% annually')
INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Partneship',500.00, 'monthly','Save 25% annually')
INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Partneship Plus',700.00, 'monthly','Save 25% annually')
INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Assistance',500.00, 'monthly','Save 25% annually')
INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Assistance Plus',700.00, 'monthly','Save 25% annually')
INSERT INTO ServiceAsked (ServiceName, Price, [Period], Note) VALUES ('Other Services',400.00, 'monthly','Save 25% annually')
INSERT INTO Sector (SectorName) VALUES ('Agriculture')
INSERT INTO Sector (SectorName) VALUES ('Food Processing')
INSERT INTO Sector (SectorName) VALUES ('Consumer Staples')
INSERT INTO Sector (SectorName) VALUES ('Consumer Discretionary')
INSERT INTO Sector (SectorName) VALUES ('Mining')
INSERT INTO Sector (SectorName) VALUES ('Energy')
INSERT INTO Sector (SectorName) VALUES ('Industrials')
INSERT INTO Sector (SectorName) VALUES ('Commercial & Professional Services')
INSERT INTO Sector (SectorName) VALUES ('Capital Goods')
INSERT INTO Sector (SectorName) VALUES ('Transportation')
INSERT INTO Sector (SectorName) VALUES ('Textiles')
INSERT INTO Sector (SectorName) VALUES ('Basic Materials')
INSERT INTO Sector (SectorName) VALUES ('Utilities')
INSERT INTO Sector (SectorName) VALUES ('Financials')
INSERT INTO Sector (SectorName) VALUES ('Real Estate')
INSERT INTO Sector (SectorName) VALUES ('Technology & Telecommunications')
INSERT INTO Sector (SectorName) VALUES ('HealthCare')
INSERT INTO Category ([Name], [Url], [Deleted], [Visible]) VALUES ('Consumer Staples','cstaples',0,1)
INSERT INTO Category ([Name], [Url], [Deleted], [Visible]) VALUES ('Agriculture','agri',0,1)
INSERT INTO Category ([Name], [Url], [Deleted], [Visible]) VALUES ('Food Processing','food',0,1)
INSERT INTO Category ([Name], [Url], [Deleted], [Visible]) VALUES ('Mining','mines',0,1)
INSERT INTO Category ([Name], [Url], [Deleted], [Visible]) VALUES ('Consumer Discretionary','cdiscr',0,1)
INSERT INTO Category ([Name], [Url], [Deleted], [Visible]) VALUES ('Industrials','industrials',0,1)
INSERT INTO Category ([Name], [Url], [Deleted], [Visible]) VALUES ('Commercials','commerce',0,1)
INSERT INTO Category ([Name], [Url], [Deleted], [Visible]) VALUES ('Transportation','transport',0,1)
INSERT INTO Category ([Name], [Url], [Deleted], [Visible]) VALUES ('Capital Goods','cgoods',0,1)
INSERT INTO Category ([Name], [Url], [Deleted], [Visible]) VALUES ('Textiles','textile',0,1)
INSERT INTO Category ([Name], [Url], [Deleted], [Visible]) VALUES ('Energy','energy',0,1)
INSERT INTO Category ([Name], [Url], [Deleted], [Visible]) VALUES ('Materials','materials',0,1)
INSERT INTO Category ([Name], [Url], [Deleted], [Visible]) VALUES ('Financials','financials',0,1)
INSERT INTO Category ([Name], [Url], [Deleted], [Visible]) VALUES ('Technology & Telecommunications','ict',0,1)
INSERT INTO Category ([Name], [Url], [Deleted], [Visible]) VALUES ('HealthCare','healthcare',0,1)
EXEC AddProductType 'Default'
EXEC AddProductType 'Agriculture'
EXEC AddProductType 'Fish & Farming'
EXEC AddProductType 'Food Processing'
EXEC AddProductType 'Livestock'
EXEC AddProductType 'Beverages'
EXEC AddProductType 'Tobacco'
EXEC AddProductType 'Household & Personal Products'
EXEC AddProductType 'Construction & Engineering'
EXEC AddProductType 'Construction Materials'
EXEC AddProductType 'Building Products'
EXEC AddProductType 'Trading & Distributing'
EXEC AddProductType 'Commercial Services & Supplies'
EXEC AddProductType 'Hotels & Entertainment Services'
EXEC AddProductType 'Media and Publishing'
EXEC AddProductType 'Retailers & Distributors'
EXEC AddProductType 'Automobiles & Auto Parts'
EXEC AddProductType 'Pharmaceutical and Heathcare Services'
EXEC AddProductType 'Technology & Internet Services'
EXEC AddProductType 'Telecommunication Services & Equipment'
EXEC AddProductType 'Technology Hardware & Equipment'
EXEC AddProductType 'Software & Services'
EXEC AddProductType 'Water Utilities'
EXEC AddProductType 'Natural Gas Utilities'
EXEC AddProductType 'Electric Utilities'
EXEC AddProductType 'Multiline Utilities'
EXEC AddProductType 'Machinery & Equipment Components'
EXEC AddProductType 'Aerospace & Defense'
EXEC AddProductType 'Paper & Forest Products'
EXEC AddProductType 'Chemicals'
EXEC AddProductType 'Fertilizers & Agricultural Chemicals'
EXEC AddProductType 'Renewable Energy'
EXEC AddProductType 'Energy Equipment & Services'
EXEC AddProductType 'Oil and Gas Equipment - Services'
EXEC AddProductType 'Oil, Gas & Consumable Fuels'
EXEC AddProductType 'Coal'
EXEC AddProductType 'Diversified Metals & Mining'
EXEC AddProductType 'Transportation Infrastructure'
EXEC AddProductType 'Air Freight & Logistics'
EXEC AddProductType 'Airlines'
EXEC AddProductType 'Road & Rail'
EXEC AddProductType 'Electrical Equipment'
EXEC AddProductType 'Containers & Packaging'
EXEC AddProductType 'Industrial Conglomerates'
EXEC AddProductType 'Textiles, Apparel & Luxury Goods'
EXEC AddProductType 'Semiconductors & Semiconductor Equipment'
EXEC AddProductType 'Education Services'
EXEC AddProductType 'Diversified Consumer Services'
EXEC AddProductType 'Professional Services'
EXEC AddProductType 'Mining'
EXEC AddProductType 'Metals'
EXEC AddProductType 'Precious Metals & Minerals'
EXEC AddProductType 'Gold'
EXEC AddProductType 'Copper'
EXEC AddProductType 'Steel'
EXEC AddProductType 'Silver'
EXEC AddProductType 'Aluminium'
EXEC AddProductType 'Diversified Financials Services'
EXEC AddProductType 'Banking & Investment Services'
EXEC AddProductType 'Banks and Insurance'
EXEC AddProductType 'Equity Real Estate Investment Trusts (REITs)'
EXEC AddProductType 'Real Estate'
EXEC AddProductType 'East Africa'
EXEC AddProductType 'West Africa'
EXEC AddProductType 'South Africa'
EXEC AddProductType 'North Africa'
EXEC AddProductType 'Central Africa'
EXEC AddProductType 'Europe'
EXEC AddProductType 'European Union (EU)'
EXEC AddProductType 'Eastern Europe'
EXEC AddProductType 'Middle East'
EXEC AddProductType 'GCC'
EXEC AddProductType 'Asia'
EXEC AddProductType 'Asia-Pacific'
EXEC AddProductType 'America'
EXEC AddProductType 'North America'
EXEC AddProductType 'South America'
EXEC AddProductType 'Global'
EXEC AddProductType 'China'
EXEC AddProductType 'USA'
EXEC AddProductType 'Africa'
EXEC AddProductType 'Other'
INSERT INTO FavoriteProductType ([AppUserId],[ProdtypeId]) VALUES (4,2)
INSERT INTO FavoriteProductType ([AppUserId],[ProdtypeId]) VALUES (4,10)
INSERT INTO FavoriteProductType ([AppUserId],[ProdtypeId]) VALUES (4,5)
INSERT INTO FavoriteProductType ([AppUserId],[ProdtypeId]) VALUES (2,23)
INSERT INTO FavoriteProductType ([AppUserId],[ProdtypeId]) VALUES (2,29)
INSERT INTO FavoriteProductType ([AppUserId],[ProdtypeId]) VALUES (3,30)
INSERT INTO FavoriteProductType ([AppUserId],[ProdtypeId]) VALUES (3,31)
INSERT INTO FavoriteProductType ([AppUserId],[ProdtypeId]) VALUES (5,34)
INSERT INTO FavoriteProductType ([AppUserId],[ProdtypeId]) VALUES (5,41)
INSERT INTO FavoriteProductType ([AppUserId],[ProdtypeId]) VALUES (6,51)
INSERT INTO FavoriteProductType ([AppUserId],[ProdtypeId]) VALUES (6,62)
INSERT INTO FavoriteProductType ([AppUserId],[ProdtypeId]) VALUES (1,2)
INSERT INTO FavoriteProductType ([AppUserId],[ProdtypeId]) VALUES (1,32)
INSERT INTO FavoriteProductType ([AppUserId],[ProdtypeId]) VALUES (1,19)
INSERT INTO FavoriteProductType ([AppUserId],[ProdtypeId]) VALUES (1,50)
EXEC AddSupplier 4,'Wakanda PLC','https://static.wikia.nocookie.net/marveldatabase/images/4/44/Flag_of_Wakanda_from_Black_Panther_Vol_6_4_0001.jpg',1,2,'Kolo Touré','002544526542212','kolotoure@wakandaplc.com','http://www.test.com','AsorokoStreet Avenue 254 - Building A20','Accra','Ghana','Need a global partner to collaborate on longtime basis in future'
EXEC AddProduct 'Ethiopian Blessed Coffee - (Organic)','https://media1.coffee-webstore.com/img/cms/Blog/2014-2016/caf%C3%A9-am%C3%A9ricain.jpg','Since immemorial times ago, Ethiopia has played a leading role in the history of coffee. The beans for this Ethiopian Blessed Coffee, grown organically, come from the Limu region. The secret of Limu coffee is probably the best kept secret in the world... This sumptuous single-origin coffee unfolds an extremely refined taste: the chocolate notes combined with the fruity sweetness guarantee a masterful balance','Ethiopia',2
EXEC AddProductVariant 1, 2, 9.99, 19.99
EXEC AddBuyer 6, '+32(0)455 66 22 33', 'Drongen-Ghent','Belgium','KDB Company','http://www.kdb.test'
EXEC AddAddress 4, 'Quartier Plateaux', 'Abidjan', '', 225, 'Ivory Coast'
EXEC AddComment 5, 1, 'Too much morning, not enough coffee:) This coffee gave me really a brew-tiful day.:)'
INSERT INTO SupplyItems ([UserId], [ProductId], [ProductTypeId], [Quantity], [TotalPrice]) VALUES (4,1,2,45,99.25)