CREATE TABLE [dbo].[GrfrHistories] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [DrId]        INT            NOT NULL,
    [GrfrDate]    DATETIME       NOT NULL,
    [EnteredBy]   NVARCHAR (255) NOT NULL,
    [EnteredDate] DATETIME       NOT NULL,
    CONSTRAINT [PK_GrfrHistories] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_GrfrHistories_Drs] FOREIGN KEY ([DrId]) REFERENCES [dbo].[Drs] ([Id])
);

