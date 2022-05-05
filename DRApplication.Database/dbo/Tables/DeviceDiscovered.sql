CREATE TABLE [dbo].[DeviceDiscovered] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [IssueId]  INT NOT NULL,
    [DeviceId] INT NOT NULL,
    CONSTRAINT [PK_DeviceDiscovered] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DeviceDiscovered_Devices] FOREIGN KEY ([DeviceId]) REFERENCES [dbo].[Devices] ([Id]),
    CONSTRAINT [FK_DeviceDiscovered_Issues] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issues] ([Id])
);

