CREATE TABLE [dbo].[HardwareVersionsConfigs] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [HardwareVersionId] INT NOT NULL,
    [HardwareConfigId]  INT NOT NULL,
    CONSTRAINT [PK_HardwareVersionsConfigs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_HardwareVersionsConfigs_HardwareConfigs] FOREIGN KEY ([HardwareConfigId]) REFERENCES [dbo].[HardwareConfigs] ([Id]),
    CONSTRAINT [FK_HardwareVersionsConfigs_HardwareVersions] FOREIGN KEY ([HardwareVersionId]) REFERENCES [dbo].[HardwareVersions] ([Id])
);

