CREATE TABLE [dbo].[IssueConfigurations] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [IssueId]  INT NOT NULL,
    [ConfigId] INT NOT NULL,
    CONSTRAINT [PK_IssueConfigurations] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_IssueConfigurations_Issues] FOREIGN KEY ([IssueId]) REFERENCES [dbo].[Issues] ([Id]),
    CONSTRAINT [FK_IssueConfigurations_RctdConfigurations] FOREIGN KEY ([ConfigId]) REFERENCES [dbo].[RctdConfigurations] ([Id])
);

