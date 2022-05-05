CREATE TABLE [dbo].[StatusChanges] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [IssueId]     INT           NOT NULL,
    [SimStatusId] INT           NOT NULL,
    [EnteredBy]   NVARCHAR (50) NOT NULL,
    [EnteredDate] DATETIME      NOT NULL,
    CONSTRAINT [PK_StatusChanges] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StatusChanges_Issues] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issues] ([Id]),
    CONSTRAINT [FK_StatusChanges_SimStatuses] FOREIGN KEY ([SimStatusId]) REFERENCES [dbo].[SimStatuses] ([Id])
);

