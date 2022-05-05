CREATE TABLE [dbo].[TestEvents] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [TestEventDate] DATETIME       NOT NULL,
    [Name]          NVARCHAR (255) NOT NULL,
    [DeviceId]      INT            NOT NULL,
    CONSTRAINT [PK_TestEvents] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TestEvents_Devices] FOREIGN KEY ([DeviceId]) REFERENCES [dbo].[Devices] ([Id])
);

