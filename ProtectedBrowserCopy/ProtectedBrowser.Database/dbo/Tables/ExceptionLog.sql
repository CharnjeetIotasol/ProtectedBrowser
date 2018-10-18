CREATE TABLE [dbo].[ExceptionLog] (
    [Id]         BIGINT             IDENTITY (1, 1) NOT NULL,
    [Source]     NVARCHAR (1000)    NOT NULL,
    [Message]    NVARCHAR (1000)    NOT NULL,
    [StackTrace] NVARCHAR (MAX)     NOT NULL,
    [Uri]        NVARCHAR (1000)    NOT NULL,
    [method]     NVARCHAR (50)      NOT NULL,
    [CreatedBy]  BIGINT             NULL,
    [IsDeleted]  BIT                CONSTRAINT [DF_ExceptionLog_IsDeleted] DEFAULT ((0)) NOT NULL,
    [CreatedOn]  DATETIMEOFFSET (7) CONSTRAINT [DF_ExceptionLog_CreatedOn] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    CONSTRAINT [PK_ExceptionLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);

