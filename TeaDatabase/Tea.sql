CREATE TABLE [dbo].[Tea]
(
	[TeaID] INT NOT NULL PRIMARY KEY, 
    [TeaName] NVARCHAR(100) UNIQUE NOT NULL, 
    [Type] NCHAR(50) NOT NULL, 
    [Subtype] NCHAR(50) NULL, 
    [CountryOfOrigin] NCHAR(100) NOT NULL, 
    [Region] NCHAR(50) NULL, 
    [HarvestSeason] NCHAR(10) NULL, 
    [OxidationLevel] INT NULL, 
    [ProcessingMethod] NVARCHAR(50) NULL, 
    [CaffeinePerSeving] INT NULL, --In mg per 8 oz serving 
    [CaffeineLevel] NCHAR(10) NULL, 
    [RecTemp] INT NOT NULL, --In celsius
    [RecSteepTime] INT NOT NULL,  --In seconds
    [RecWaterAmount] INT NULL, --In mls
    [Description] NVARCHAR(500) NULL, 
    [ImageURL] NCHAR(50) NULL, 
    [AvgRating] FLOAT NULL
)
