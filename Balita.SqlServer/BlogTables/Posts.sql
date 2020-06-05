CREATE TABLE [dbo].[Posts]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CategoryId] INT NOT NULL, 
    [PostedDate] DATETIME2 NOT NULL, 
    [CommentCount] INT NOT NULL, 
    [PostHeadline] NVARCHAR(150) NOT NULL, 
    [PostText] NVARCHAR(MAX) NOT NULL, 
    [Image] VARBINARY(MAX) NOT NULL
)
