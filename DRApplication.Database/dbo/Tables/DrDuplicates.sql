CREATE TABLE [dbo].[DrDuplicates] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [Drid]    INT NOT NULL,
    [DupDrid] INT NOT NULL,
    CONSTRAINT [PK_DrDuplicates] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_DrDuplicates_Drs] FOREIGN KEY ([Drid]) REFERENCES [dbo].[Drs] ([Id])
);

