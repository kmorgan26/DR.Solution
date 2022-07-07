CREATE TABLE [dbo].[HardwareSystems] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (25) NOT NULL,
    CONSTRAINT [PK_HardwareSystems] PRIMARY KEY CLUSTERED ([Id] ASC)
);



