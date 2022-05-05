CREATE TABLE [dbo].[DrTypes] (
    [Id]   INT         IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (5) NOT NULL,
    CONSTRAINT [PK_DrTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

