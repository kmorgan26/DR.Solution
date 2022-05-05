CREATE TABLE [dbo].[SsrdTasks] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [DeviceTypeId] INT           NOT NULL,
    CONSTRAINT [PK_SsrdTasks] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SsrdTasks_DeviceTypes] FOREIGN KEY ([DeviceTypeId]) REFERENCES [dbo].[DeviceTypes] ([Id])
);

