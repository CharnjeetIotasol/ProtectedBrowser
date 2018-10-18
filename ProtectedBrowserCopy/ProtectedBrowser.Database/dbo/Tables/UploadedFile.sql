CREATE TABLE [dbo].[UploadedFile] (
    [Id]        BIGINT             IDENTITY (1, 1) NOT NULL,
    [FileName]  NVARCHAR (250)     NULL,
    [FileUrl]   NVARCHAR (MAX)     NULL,
    [IsDeleted] BIT                DEFAULT ((0)) NULL,
    [CreatedOn] DATETIMEOFFSET (7) DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

