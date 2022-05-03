CREATE TABLE [dbo].[Devices] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (20) NOT NULL,
    [DeviceTypeId] INT          NOT NULL,
    [IsActive]     BIT          NOT NULL,
    CONSTRAINT [PK_Devices] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Devices_DeviceTypes] FOREIGN KEY ([DeviceTypeId]) REFERENCES [dbo].[DeviceTypes] ([Id])
);

