CREATE TABLE [dbo].[SpecificLoads] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [LoadId]   INT NOT NULL,
    [DeviceId] INT NOT NULL,
    CONSTRAINT [PK_SpecificLoad] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SpecificLoads_Devices] FOREIGN KEY ([DeviceId]) REFERENCES [dbo].[Devices] ([Id]),
    CONSTRAINT [FK_SpecificLoads_Loads] FOREIGN KEY ([LoadId]) REFERENCES [dbo].[Loads] ([Id])
);

