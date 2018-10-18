CREATE TABLE [dbo].[DummyTableForFile] (
    [Id]          BIGINT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100)     NULL,
    [IsDeleted]   BIT                CONSTRAINT [DF_DummyTableForFile_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsActive]    BIT                CONSTRAINT [DF_DummyTableForFile_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]   BIGINT             NULL,
    [UpdatedBy]   BIGINT             NULL,
    [CreatedOn]   DATETIMEOFFSET (7) CONSTRAINT [DF_DummyTableForFile_CreatedOn] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    [UpdatedOn]   DATETIMEOFFSET (7) CONSTRAINT [DF_DummyTableForFile_UpdatedOn] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    [FileGroupId] BIGINT             NULL,
    CONSTRAINT [PK_DummyTableForFile] PRIMARY KEY CLUSTERED ([Id] ASC)
);

