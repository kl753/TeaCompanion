CREATE TABLE [dbo].[Tea]
(
	[TeaID] INT NOT NULL PRIMARY KEY, 
    [TeaName] NVARCHAR(50) UNIQUE NOT NULL, 
    [Type] NCHAR(10) NOT NULL, 
    [Subtype] NCHAR(10) NULL, 
    [CountryOrigin] NCHAR(10) NOT NULL, 
    [Region] NCHAR(10) NULL, 
    [HarvestSeason] NCHAR(10) NULL, 
    [OxidationLevel] INT NULL, 
    [ProcessingMethod] NVARCHAR(50) NULL, 
    [CaffeinePerSeving] INT NULL, --In mg per 8 oz serving 
    [CaffeineLevel] NCHAR(10) NULL, 
    [RecTemp] INT NOT NULL, --In celsius
    [RecSteepTime] INT NOT NULL,  --In seconds
    [RecWaterAmount] INT NULL, --In mls
    [Description] NVARCHAR(50) NULL, 
    [ImageURL] NCHAR(10) NULL, 
    [AvgRating] FLOAT NULL
)
