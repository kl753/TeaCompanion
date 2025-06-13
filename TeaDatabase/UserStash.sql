CREATE TABLE [dbo].[UserStash]
(
	[StashItemID] INT NOT NULL PRIMARY KEY, 
    [UserID] INT NOT NULL,
	[TeaID] INT NOT NULL, 
    [Quanity] FLOAT NULL, --In grams 
    [PurchaseDate] DATE NULL, 
    [Source] NVARCHAR(50) NULL, 
    [StorageNotes] TEXT NULL, 
    [PersonalNotes] TEXT NULL, 
    [IsCustomTea] BIT NULL DEFAULT 0, 
    [CustomDescription] TEXT NULL, 
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserID]),
	FOREIGN KEY ([TeaID]) REFERENCES [dbo].[Tea] ([TeaID]),

)
