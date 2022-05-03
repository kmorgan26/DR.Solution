CREATE TABLE [dbo].[Keywords] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (255) NOT NULL,
    [DeviceTypeId]   INT            CONSTRAINT [DF_Keywords_DeviceTypeId] DEFAULT ((0)) NOT NULL,
    [DeviceSpecific] BIT            NOT NULL,
    CONSTRAINT [PK_Keywords] PRIMARY KEY CLUSTERED ([Id] ASC)
);

