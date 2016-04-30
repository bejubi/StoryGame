CREATE TABLE [dbo].[GameLine]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY default newid(),
	[GameId] uniqueidentifier NOT NULL foreign key references Game(Id),
	[UserId] uniqueidentifier NOT NULL foreign key references [User](Id),
	[CreateDate] datetime NOT NULL default getdate(),
	[Text] nvarchar(4000) NOT NULL
)
