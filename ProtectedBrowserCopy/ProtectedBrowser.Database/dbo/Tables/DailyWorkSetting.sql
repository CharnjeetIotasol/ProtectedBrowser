CREATE TABLE [dbo].[DailyWorkSetting] (
    [Id]             INT                IDENTITY (1, 1) NOT NULL,
    [Sunday]         BIT                NOT NULL,
    [Monday]         BIT                NOT NULL,
    [Tuesday]        BIT                NOT NULL,
    [Wednesday]      BIT                NOT NULL,
    [Thursday]       BIT                NOT NULL,
    [Friday]         BIT                NOT NULL,
    [Satureday]      BIT                NOT NULL,
    [StartTime]      TIME (7)           NULL,
    [EndTime]        TIME (7)           NULL,
    [StartLunchTime] TIME (7)           NULL,
    [EndLunchTime]   TIME (7)           NULL,
    [CreatedBy]      BIGINT             NULL,
    [UpdatedBy]      BIGINT             NULL,
    [UpdatedDate]    DATETIMEOFFSET (7) CONSTRAINT [DF_DailyWorkSetting_UpdatedDate] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    CONSTRAINT [PK__DailyWor__3214EC07EC0ABD93] PRIMARY KEY CLUSTERED ([Id] ASC)
);

