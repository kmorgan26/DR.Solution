CREATE TABLE [dbo].[UserLogs] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [UserName]      NVARCHAR (50) NOT NULL,
    [IpAddress]     NVARCHAR (25) NOT NULL,
    [LoginDateTime] DATETIME      NOT NULL,
    [IsSuccess]     BIT           NOT NULL,
    CONSTRAINT [PK_UserLogs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

