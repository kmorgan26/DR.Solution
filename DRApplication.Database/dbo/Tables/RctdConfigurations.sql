CREATE TABLE [dbo].[RctdConfigurations] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_RctdConfigurations] PRIMARY KEY CLUSTERED ([Id] ASC)
);

