CREATE TABLE [dbo].[ServiceAsked]
(
	[Id] INT NOT NULL IDENTITY, 
    [ServiceName] VARCHAR(250) NOT NULL,	
	[Price] DECIMAL(18,2) NOT NULL, 
    [Period] VARCHAR(50) NOT NULL, 
    [Note] VARCHAR(80) NOT NULL
    CONSTRAINT [PK_Service] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Service_ServiceName] UNIQUE (ServiceName)
    
)
