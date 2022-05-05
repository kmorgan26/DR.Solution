CREATE TABLE [dbo].[Issues] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [DrTypeId]    INT            NOT NULL,
    [SimStatusId] INT            NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [IssueDate]   DATETIME       NOT NULL,
    [EnteredBy]   NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Issues] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Issues_DrTypes] FOREIGN KEY ([DrTypeId]) REFERENCES [dbo].[DrTypes] ([Id]),
    CONSTRAINT [FK_Issues_SimStatuses] FOREIGN KEY ([SimStatusId]) REFERENCES [dbo].[SimStatuses] ([Id])
);

