CREATE TABLE [dbo].[HardwareVersions] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (25) NOT NULL,
    [HardwareSystemId] INT          NOT NULL,
    [VersionDate]      DATETIME     NOT NULL,
    CONSTRAINT [PK_HardwareVersions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_HardwareVersions_HardwareSystems] FOREIGN KEY ([HardwareSystemId]) REFERENCES [dbo].[HardwareSystems] ([Id])
);



