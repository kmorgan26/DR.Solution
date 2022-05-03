CREATE TABLE [dbo].[TestEventIssues] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [TestEventId] INT NOT NULL,
    [IssueId]     INT NOT NULL,
    CONSTRAINT [PK_TestEventIssues] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TestEventIssues_Issues] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issues] ([Id]),
    CONSTRAINT [FK_TestEventIssues_TestEvents] FOREIGN KEY ([TestEventId]) REFERENCES [dbo].[TestEvents] ([Id])
);

