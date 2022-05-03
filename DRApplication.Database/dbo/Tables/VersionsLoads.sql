CREATE TABLE [dbo].[VersionsLoads] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [LoadId]            INT NOT NULL,
    [SoftwareVersionId] INT NOT NULL,
    CONSTRAINT [PK_HostPartsLoads] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_VersionsLoads_Loads] FOREIGN KEY ([LoadId]) REFERENCES [dbo].[Loads] ([Id]),
    CONSTRAINT [FK_VersionsLoads_SofwareVersions] FOREIGN KEY ([SoftwareVersionId]) REFERENCES [dbo].[SoftwareVersions] ([Id])
);

