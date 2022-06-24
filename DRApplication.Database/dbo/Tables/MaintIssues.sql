CREATE TABLE [dbo].[MaintIssues] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [IssueId]            INT           NOT NULL,
    [Pid]                NVARCHAR (10) NOT NULL,
    [CorrectiveActionId] INT           NOT NULL,
    [ActionTaken]        VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_MaintIssues] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MaintIssues_CorrectiveActions] FOREIGN KEY ([CorrectiveActionId]) REFERENCES [dbo].[CorrectiveActions] ([Id]),
    CONSTRAINT [FK_MaintIssues_Issues] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issues] ([Id])
);



