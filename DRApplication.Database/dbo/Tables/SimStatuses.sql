CREATE TABLE [dbo].[SimStatuses] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (25) NOT NULL,
    [SimStatusTypeId]  INT           NOT NULL,
    [IssueDisplayName] NVARCHAR (25) NOT NULL,
    [IsActive]         BIT           NOT NULL,
    CONSTRAINT [PK_SimStatuses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SimStatuses_SimStatusTypes] FOREIGN KEY ([SimStatusTypeId]) REFERENCES [dbo].[SimStatusTypes] ([Id])
);

