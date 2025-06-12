CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [UserName] NVARCHAR(50) UNIQUE NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [PasswordHash] NVARCHAR(50) NOT NULL, 
    [FirstName] NCHAR(10) NULL, 
    [LastName] NCHAR(10) NULL, 
    [JoinDate] TIMESTAMP NOT NULL, 
    [LastLogin] TIMESTAMP NULL, 
    [IsAdmin] BIT NULL DEFAULT 0,
)
