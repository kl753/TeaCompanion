CREATE TABLE [dbo].[BrewSession]
(
	[BrewID] INT NOT NULL PRIMARY KEY, 
    [StashItemID] INT NOT NULL,
	[UserID] int NOT NULL, 
    [Timestamp] TIMESTAMP NOT NULL, 
    [Temp] INT NOT NULL, --Celsius
    [SteepTime] INT NOT NULL, --Seconds 
    [WaterAmount] INT NULL, --Mls
    [UserRating] INT NULL, 
    [BrewNotes] TEXT NULL, 
    [BrewMethod] TEXT NULL, 
    FOREIGN KEY ([StashItemID]) REFERENCES [dbo].[UserStash] ([StashItemID]),
	FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserID]),
)
