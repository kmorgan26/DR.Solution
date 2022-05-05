CREATE TABLE [dbo].[Drrbs] (
    [Id]           INT      IDENTITY (1, 1) NOT NULL,
    [DrrbDate]     DATETIME NOT NULL,
    [DeviceTypeId] INT      NOT NULL,
    CONSTRAINT [PK_Drrbs] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Drrbs_DeviceTypes] FOREIGN KEY ([DeviceTypeId]) REFERENCES [dbo].[DeviceTypes] ([Id])
);

