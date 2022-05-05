CREATE TABLE [dbo].[LoadsDevices] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [DeviceId] INT NOT NULL,
    [LoadId]   INT NOT NULL,
    CONSTRAINT [PK_LoadsDevices] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LoadsDevices_Devices] FOREIGN KEY ([DeviceId]) REFERENCES [dbo].[Devices] ([Id]),
    CONSTRAINT [FK_LoadsDevices_Loads] FOREIGN KEY ([LoadId]) REFERENCES [dbo].[Loads] ([Id])
);

