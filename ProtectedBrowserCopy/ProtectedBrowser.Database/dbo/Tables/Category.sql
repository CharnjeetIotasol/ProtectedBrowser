CREATE TABLE [dbo].[Category] (
    [Id]           BIGINT             IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (100)     NOT NULL,
    [IsDeleted]    BIT                CONSTRAINT [DF_Category_IsDeleted] DEFAULT ((0)) NOT NULL,
    [CreatedOn]    DATETIMEOFFSET (7) CONSTRAINT [DF_Category_CreatedOn] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    [UpdatedOn]    DATETIMEOFFSET (7) CONSTRAINT [DF_Category_UpdatedOn] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    [IsActive]     BIT                CONSTRAINT [DF_Category_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]    BIGINT             NULL,
    [UpdatedBy]    BIGINT             NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
);








GO
ALTER TABLE [dbo].[Category] SET (LOCK_ESCALATION = AUTO);

