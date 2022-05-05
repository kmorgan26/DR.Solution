CREATE TABLE [dbo].[Baselines] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [BaseLineDate] DATETIME       NOT NULL,
    [DrId]         INT            NOT NULL,
    [EnteredDate]  DATETIME       NOT NULL,
    [EnteredBy]    NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Baselines] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Baselines_Drs] FOREIGN KEY ([DrId]) REFERENCES [dbo].[Drs] ([Id])
);

