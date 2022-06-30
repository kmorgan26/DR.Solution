CREATE TABLE [dbo].[Maintainers] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (25) NOT NULL,
    CONSTRAINT [PK_Maintainers] PRIMARY KEY CLUSTERED ([Id] ASC)
);



