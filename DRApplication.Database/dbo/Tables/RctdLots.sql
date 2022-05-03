CREATE TABLE [dbo].[RctdLots] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (10) NOT NULL,
    [DeviceTypeId] INT          NOT NULL,
    CONSTRAINT [PK_RctdLots] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RctdLots_DeviceTypes] FOREIGN KEY ([DeviceTypeId]) REFERENCES [dbo].[DeviceTypes] ([Id])
);

