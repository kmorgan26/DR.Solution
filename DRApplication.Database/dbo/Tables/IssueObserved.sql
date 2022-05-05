CREATE TABLE [dbo].[IssueObserved] (
    [Id]           INT      IDENTITY (1, 1) NOT NULL,
    [IssueId]      INT      NOT NULL,
    [DeviceId]     INT      NOT NULL,
    [DateObserved] DATETIME NOT NULL,
    CONSTRAINT [PK_IssueObserved] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_IssueObserved_Devices] FOREIGN KEY ([DeviceId]) REFERENCES [dbo].[Devices] ([Id]),
    CONSTRAINT [FK_IssueObserved_Issues] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issues] ([Id])
);

