CREATE TABLE [dbo].[IssuesDevices] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [IssueId]  INT NOT NULL,
    [DeviceId] INT NOT NULL,
    CONSTRAINT [PK_IssueDevices] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_IssueDevices_Devices] FOREIGN KEY ([DeviceId]) REFERENCES [dbo].[Devices] ([Id]),
    CONSTRAINT [FK_IssueDevices_Issues] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issues] ([Id])
);

