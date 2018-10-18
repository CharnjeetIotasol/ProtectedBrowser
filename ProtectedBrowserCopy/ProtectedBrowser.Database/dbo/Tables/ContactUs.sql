CREATE TABLE [dbo].[ContactUs] (
    [Id]           BIGINT             IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (100)     NOT NULL,
    [PhoneNumber]  NVARCHAR (25)      NULL,
    [EmailAddress] NVARCHAR (100)     NULL,
    [CreatedOn]    DATETIMEOFFSET (7) CONSTRAINT [DF_ContactUs_CreatedDate] DEFAULT (switchoffset(sysdatetimeoffset(),'+00:00')) NULL,
    [IsDeleted]    BIT                CONSTRAINT [DF_ContactUs_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Message]      NVARCHAR (MAX)     NOT NULL,
    CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED ([Id] ASC)
);



