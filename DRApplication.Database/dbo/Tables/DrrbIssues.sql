CREATE TABLE [dbo].[DrrbIssues] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [DrrbId]  INT NOT NULL,
    [IssueId] INT NOT NULL,
    CONSTRAINT [PK_DrrbIssues] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DrrbIssues_Drrbs] FOREIGN KEY ([DrrbId]) REFERENCES [dbo].[Drrbs] ([Id]),
    CONSTRAINT [FK_DrrbIssues_Issues] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issues] ([Id])
);

