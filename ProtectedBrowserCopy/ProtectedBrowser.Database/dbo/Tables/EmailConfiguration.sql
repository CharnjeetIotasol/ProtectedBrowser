CREATE TABLE [dbo].[EmailConfiguration] (
    [Id]                 INT                IDENTITY (1, 1) NOT NULL,
    [ConfigurationKey]   NVARCHAR (200)     NULL,
    [ConfigurationValue] NVARCHAR (MAX)     NULL,
    [EmailSubject]       NCHAR (1000)       NULL,
    [CreatedDate]        DATETIMEOFFSET (7) CONSTRAINT [DF_EmailConfiguration_CreatedDate] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    [CreatedBy]          BIGINT             NULL,
    [IsDeleted]          INT                CONSTRAINT [DF_EmailConfiguration_IsDeleted] DEFAULT ((0)) NOT NULL
);
