CREATE TABLE [dbo].[PublicHolidays] (
    [Id]           BIGINT             IDENTITY (1, 1) NOT NULL,
    [StartHoliday] DATETIMEOFFSET (7) NULL,
    [Description]  NVARCHAR (MAX)     NULL,
    [IsDeleted]    BIT                CONSTRAINT [DF_PublicHolidays_IsDeleted] DEFAULT ((0)) NOT NULL,
    [CreatedDate]  DATETIMEOFFSET (7) CONSTRAINT [DF_PublicHolidays_CreatedDate] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    [UpdatedDate]  DATETIMEOFFSET (7) CONSTRAINT [DF_PublicHolidays_UpdatedDate] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    [CreatedBy]    BIGINT             NULL,
    [UpdatedBy]    BIGINT             NULL,
    [EndHoliday]   DATETIMEOFFSET (7) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

