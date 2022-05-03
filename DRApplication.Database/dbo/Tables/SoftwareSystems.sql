CREATE TABLE [dbo].[SoftwareSystems] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (50) NOT NULL,
    [HardwareConfigId] INT          NOT NULL,
    CONSTRAINT [PK_HostParts] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SoftwareSystems_HardwareConfigs] FOREIGN KEY ([HardwareConfigId]) REFERENCES [dbo].[HardwareConfigs] ([Id])
);

