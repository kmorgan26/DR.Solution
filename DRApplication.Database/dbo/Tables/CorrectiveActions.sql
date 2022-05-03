CREATE TABLE [dbo].[CorrectiveActions] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_CorrectiveActions] PRIMARY KEY CLUSTERED ([Id] ASC)
);

