CREATE TABLE [dbo].[CurrentLoads] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [LoadId]   INT NOT NULL,
    [DeviceId] INT NOT NULL,
    CONSTRAINT [PK_CurrentLoads] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CurrentLoads_Devices] FOREIGN KEY ([DeviceId]) REFERENCES [dbo].[Devices] ([Id]),
    CONSTRAINT [FK_CurrentLoads_Loads] FOREIGN KEY ([LoadId]) REFERENCES [dbo].[Loads] ([Id])
);




