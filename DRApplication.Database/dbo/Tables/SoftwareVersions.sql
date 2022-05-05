CREATE TABLE [dbo].[SoftwareVersions] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (50) NOT NULL,
    [SoftwareSystemId] INT          NOT NULL,
    [VersionDate]      DATETIME     NULL,
    CONSTRAINT [PK_HostSystemVersions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SofwareVersions_SoftwareSystems] FOREIGN KEY ([SoftwareSystemId]) REFERENCES [dbo].[SoftwareSystems] ([Id])
);

