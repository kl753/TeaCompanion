CREATE TABLE [dbo].[TeaFlavor] --Junction table
(
	[TeaID] INT NOT NULL, 
    [TagID] INT NOT NULL,
	PRIMARY KEY ([TeaID], [TagID]),
	FOREIGN KEY ([TeaID]) REFERENCES [dbo].[Tea] ([TeaID]),
	FOREIGN KEY ([TagID]) REFERENCES [dbo].[FlavorTag] ([TagID]),
)
