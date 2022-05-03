CREATE TABLE [dbo].[Comments] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [IssueId]     INT            NOT NULL,
    [CommentText] NVARCHAR (MAX) NOT NULL,
    [CommentDate] DATETIME       NOT NULL,
    [EnteredBy]   NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Comments_Issues] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issues] ([Id])
);

