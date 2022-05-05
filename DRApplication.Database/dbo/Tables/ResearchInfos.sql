CREATE TABLE [dbo].[ResearchInfos] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [IssueId]      INT           NOT NULL,
    [ResearchDate] DATETIME      NOT NULL,
    [DeadlineDate] DATETIME      NOT NULL,
    [ResearchLead] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_ResearchInfos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ResearchInfos_Issues] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issues] ([Id])
);

