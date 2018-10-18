CREATE TABLE [dbo].[Users] (
    [Id]                   BIGINT         IDENTITY (1, 1) NOT NULL,
    [IsActive]             BIT            NOT NULL,
    [IsDeleted]            BIT            NOT NULL,
    [FirstName]            NVARCHAR (MAX) NULL,
    [LastName]             NVARCHAR (MAX) NULL,
    [ProfilePic]           NVARCHAR (MAX) NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    [UniqueCode]           NVARCHAR (50)  NULL,
    [IsFacebookConnected]  BIT            CONSTRAINT [DF_Users_IsFacebookConnected] DEFAULT ((0)) NOT NULL,
    [IsGoogleConnected]    BIT            CONSTRAINT [DF_Users_IsGoogleConnected] DEFAULT ((0)) NOT NULL,
    [FacebookId]           NVARCHAR (100) NULL,
    [GoogleId]             NVARCHAR (100) NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);






GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [dbo].[Users]([UserName] ASC);

