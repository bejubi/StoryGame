CREATE TABLE [dbo].[User]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY default newid(),
	[CreateDate] datetime NOT NULL default getdate(),
	Username varchar(100) NOT NULL
)
