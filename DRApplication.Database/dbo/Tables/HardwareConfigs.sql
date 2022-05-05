CREATE TABLE [dbo].[HardwareConfigs] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50) NOT NULL,
    [DeviceTypeId] INT          NOT NULL,
    CONSTRAINT [PK_HarwareConfigs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_HardwareConfigs_DeviceTypes] FOREIGN KEY ([DeviceTypeId]) REFERENCES [dbo].[DeviceTypes] ([Id])
);

