CREATE TABLE [dbo].[FileGroup] (
    [Id]        BIGINT             IDENTITY (1, 1) NOT NULL,
    [CreatedBy] BIGINT             NULL,
    [UpdatedBy] BIGINT             NULL,
    [CreatedOn] DATETIMEOFFSET (7) CONSTRAINT [DF_Gallery_CreatedOn] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    [UpdatedOn] DATETIMEOFFSET (7) CONSTRAINT [DF_Gallery_UpdatedOn] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    [IsDeleted] BIT                CONSTRAINT [DF_Gallery_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsActive]  BIT                CONSTRAINT [DF_Gallery_IsActive] DEFAULT ((1)) NOT NULL,
    [Name]      NVARCHAR (256)     NULL,
    [Type]      NVARCHAR (50)      NULL,
    CONSTRAINT [PK_Gallery] PRIMARY KEY CLUSTERED ([Id] ASC)
);

