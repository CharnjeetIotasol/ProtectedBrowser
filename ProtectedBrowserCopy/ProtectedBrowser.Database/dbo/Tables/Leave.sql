CREATE TABLE [dbo].[Leave] (
    [Id]          BIGINT             IDENTITY (1, 1) NOT NULL,
    [CreatedBy]   BIGINT             NOT NULL,
    [UpdatedBy]   BIGINT             NOT NULL,
    [CreatedOn]   DATETIMEOFFSET (7) CONSTRAINT [DF_Leave_CreatedOn] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    [UpdatedOn]   DATETIMEOFFSET (7) CONSTRAINT [DF_Leave_UpdatedOn] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    [IsDeleted]   BIT                CONSTRAINT [DF_Leave_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsActive]    BIT                CONSTRAINT [DF_Leave_IsActive] DEFAULT ((1)) NOT NULL,
    [StartDate]   DATETIMEOFFSET (7) CONSTRAINT [DF_Leave_StartDate] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NULL,
    [EndDate]     DATETIMEOFFSET (7) CONSTRAINT [DF_Leave_EndDate] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NULL,
    [StartTime]   TIME (7)           NULL,
    [EndTime]     TIME (7)           NULL,
    [Type]        NVARCHAR (50)      NULL,
    [Description] NVARCHAR (MAX)     NULL,
    [UserId]      BIGINT             NULL,
    CONSTRAINT [PK_Leave] PRIMARY KEY CLUSTERED ([Id] ASC)
);

