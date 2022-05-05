CREATE TABLE [dbo].[ManModules] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50) NOT NULL,
    [RctdLotId] INT          NOT NULL,
    CONSTRAINT [PK_ManModules] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ManModules_RctdLots] FOREIGN KEY ([RctdLotId]) REFERENCES [dbo].[RctdLots] ([Id])
);

