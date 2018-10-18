CREATE TABLE [dbo].[Blog] (
    [Id]          BIGINT             IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (200)     NULL,
    [Description] NVARCHAR (MAX)     NULL,
    [CategoryId]  BIGINT             NULL,
    [IsActive]    BIT                CONSTRAINT [DF_Blog_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]   BIT                CONSTRAINT [DF_Blog_IsDeleted] DEFAULT ((0)) NULL,
    [CreatedOn]   DATETIMEOFFSET (7) CONSTRAINT [DF_Blog_CreatedDate] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NULL,
    [UpdatedOn]   DATETIMEOFFSET (7) CONSTRAINT [DF_Blog_UpdatedDate] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NULL,
    [CreatedBy]   BIGINT             NULL,
    [UpdatedBy]   BIGINT             NULL,
    [FileId]      BIGINT             NULL
);



