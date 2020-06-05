CREATE TABLE [dbo].[Comments]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PostId] INT NOT NULL, 
    [ResponseTo] INT NULL, 
    [UserName] NVARCHAR(150) NOT NULL, 
    [UserId] NVARCHAR(100) NOT NULL, 
    [CommentText] NVARCHAR(MAX) NOT NULL
)
