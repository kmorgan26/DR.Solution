CREATE TABLE [dbo].[DeviceTypes] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (20) NOT NULL,
    [MaintainerId] INT          NOT NULL,
    [IsActive]     BIT          NOT NULL,
    CONSTRAINT [PK_DeviceTypes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DeviceTypes_Maintainers] FOREIGN KEY ([MaintainerId]) REFERENCES [dbo].[Maintainers] ([Id])
);



