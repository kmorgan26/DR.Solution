CREATE TABLE [dbo].[TestEventDrs] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [TestEventId] INT NOT NULL,
    [DrId]        INT NOT NULL,
    CONSTRAINT [PK_TestEventDrs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TestEventDrs_Drs] FOREIGN KEY ([DrId]) REFERENCES [dbo].[Drs] ([Id]),
    CONSTRAINT [FK_TestEventDrs_TestEvents] FOREIGN KEY ([TestEventId]) REFERENCES [dbo].[TestEvents] ([Id])
);

