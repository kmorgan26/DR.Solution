CREATE TABLE [dbo].[Maintainers] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Maintainers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

