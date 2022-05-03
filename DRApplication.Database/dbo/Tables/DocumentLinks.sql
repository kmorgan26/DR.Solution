CREATE TABLE [dbo].[DocumentLinks] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (255) NOT NULL,
    [IssueId] INT            NOT NULL,
    [Url]     NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_DocumentLinks] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DocumentLinks_Issues] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issues] ([Id])
);

