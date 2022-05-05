CREATE TABLE [dbo].[LoadsTestEvents] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [TestEventId] INT NOT NULL,
    [LoadId]      INT NOT NULL,
    CONSTRAINT [PK_LoadTable] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LoadEvents_Loads] FOREIGN KEY ([LoadId]) REFERENCES [dbo].[Loads] ([Id]),
    CONSTRAINT [FK_LoadTable_TestEvents] FOREIGN KEY ([TestEventId]) REFERENCES [dbo].[TestEvents] ([Id])
);

