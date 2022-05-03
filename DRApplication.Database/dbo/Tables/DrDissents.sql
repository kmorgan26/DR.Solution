CREATE TABLE [dbo].[DrDissents] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [GditPriority]  INT NOT NULL,
    [DosPriority]   INT NOT NULL,
    [ThirdPriority] INT NOT NULL,
    [DrId]          INT NOT NULL,
    CONSTRAINT [PK_DrDissents] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DrDissents_Drs] FOREIGN KEY ([DrId]) REFERENCES [dbo].[Drs] ([Id])
);

