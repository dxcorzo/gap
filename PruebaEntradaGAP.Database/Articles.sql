CREATE TABLE [dbo].[Articles]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(500) NULL, 
    [Price] SMALLMONEY NOT NULL, 
    [Total_In_Shelf] INT NOT NULL, 
    [Total_In_Vault] INT NOT NULL, 
    [Store_Id] INT NOT NULL, 
    CONSTRAINT [FK_Articles_ToStores] FOREIGN KEY ([Store_Id]) REFERENCES [Stores]([Id])
	
)
