CREATE TABLE [dbo].[FileGroupItems] (
    [Id]           BIGINT             IDENTITY (1, 1) NOT NULL,
    [CreatedBy]    BIGINT             NOT NULL,
    [UpdatedBy]    BIGINT             NOT NULL,
    [CreatedOn]    DATETIMEOFFSET (7) CONSTRAINT [DF_AttachmentFile_CreatedOn] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    [UpdatedOn]    DATETIMEOFFSET (7) CONSTRAINT [DF_AttachmentFile_UpdatedOn] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
    [IsDeleted]    BIT                CONSTRAINT [DF_AttachmentFile_IsDeleted] DEFAULT ((0)) NOT NULL,
    [IsActive]     BIT                CONSTRAINT [DF_AttachmentFile_IsActive] DEFAULT ((1)) NOT NULL,
    [Filename]     NVARCHAR (256)     NOT NULL,
    [MimeType]     NVARCHAR (256)     NOT NULL,
    [Thumbnail]    NVARCHAR (256)     NULL,
    [Size]         BIGINT             NULL,
    [Path]         NVARCHAR (256)     NOT NULL,
    [OriginalName] NVARCHAR (256)     NULL,
    [OnServer]     NVARCHAR (256)     NULL,
    [TypeId]       BIGINT             NULL,
    [Type]         NVARCHAR (50)      NULL,
    CONSTRAINT [PK_AttachmentFile] PRIMARY KEY CLUSTERED ([Id] ASC)
);

