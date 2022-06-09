CREATE TABLE [dbo].[CurrentLoads] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [LoadId]   INT NOT NULL,
    [DeviceId] INT NOT NULL,
    CONSTRAINT [PK_CurrentLoads] PRIMARY KEY CLUSTERED ([Id] ASC)
);


