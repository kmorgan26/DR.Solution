CREATE TABLE [dbo].[IssueSsrdTasks] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [IssueId]    INT NOT NULL,
    [SsrdTaskId] INT NOT NULL,
    CONSTRAINT [PK_IssueSsrdTasks] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_IssueSsrdTasks_Issues] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issues] ([Id]),
    CONSTRAINT [FK_IssueSsrdTasks_SsrdTasks] FOREIGN KEY ([SsrdTaskId]) REFERENCES [dbo].[SsrdTasks] ([Id])
);

