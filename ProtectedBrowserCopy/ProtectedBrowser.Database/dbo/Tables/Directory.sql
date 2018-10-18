CREATE TABLE [dbo].[Directory] (
		[Id]           BIGINT             IDENTITY (1, 1) NOT NULL,
	  	[CreatedBy]    BIGINT             NOT NULL,
	  	[UpdatedBy]    BIGINT             NOT NULL,
		[CreatedOn]  DATETIMEOFFSET (7) CONSTRAINT [DF_Directory_CreatedOn] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
		[UpdatedOn]  DATETIMEOFFSET (7) CONSTRAINT [DF_Directory_UpdatedOn] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NOT NULL,
	  	[IsDeleted]    BIT               CONSTRAINT [DF_Directory_IsDeleted] DEFAULT ((0)) NOT NULL,
	  	[IsActive]    BIT               CONSTRAINT [DF_Directory_IsActive] DEFAULT ((1)) NOT NULL,
		[RootPath] NVARCHAR (MAX) NULL,
		[UserName] NVARCHAR (200) NULL,
		[Password] NVARCHAR (200) NULL,
		[Name] NVARCHAR (100) NULL,
CONSTRAINT [PK_Directory] PRIMARY KEY CLUSTERED ([Id]))