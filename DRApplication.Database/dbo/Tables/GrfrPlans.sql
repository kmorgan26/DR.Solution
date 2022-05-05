CREATE TABLE [dbo].[GrfrPlans] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [DrId]        INT            NOT NULL,
    [GrfrDate]    DATETIME       NOT NULL,
    [EnteredBy]   NVARCHAR (255) NOT NULL,
    [EnteredDate] DATETIME       NOT NULL,
    CONSTRAINT [PK_GrfrPlans] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_GrfrPlans_Drs] FOREIGN KEY ([DrId]) REFERENCES [dbo].[Drs] ([Id])
);

