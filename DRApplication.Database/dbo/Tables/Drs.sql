CREATE TABLE [dbo].[Drs] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [Priority] INT NOT NULL,
    [IssueId]  INT NOT NULL,
    CONSTRAINT [PK_Drs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Drs_Issues] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issues] ([Id])
);

