CREATE TABLE [dbo].[SimStatusTypes] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (25) NOT NULL,
    CONSTRAINT [PK_SimStatusTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

