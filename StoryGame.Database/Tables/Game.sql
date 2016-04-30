CREATE TABLE [dbo].[Game]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY default newid(),
	[CreateDate] datetime not null DEFAULT getdate()
)
