CREATE TABLE [dbo].[IssuesKeywords] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [IssueId]   INT NOT NULL,
    [KeywordId] INT NOT NULL,
    CONSTRAINT [PK_IssuesKeywords] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_IssuesKeywords_Issues] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issues] ([Id]),
    CONSTRAINT [FK_IssuesKeywords_Keywords] FOREIGN KEY ([KeywordId]) REFERENCES [dbo].[Keywords] ([Id])
);

