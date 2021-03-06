CREATE TABLE [dbo].[Loads] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (50) NOT NULL,
    [HardwareConfigId] INT          NOT NULL,
    [IsAccepted]       BIT          NOT NULL,
    CONSTRAINT [PK_Loads] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Loads_HardwareConfigs] FOREIGN KEY ([HardwareConfigId]) REFERENCES [dbo].[HardwareConfigs] ([Id])
);





