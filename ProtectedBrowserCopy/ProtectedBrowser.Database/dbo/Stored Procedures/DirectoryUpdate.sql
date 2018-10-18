-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE DirectoryUpdate
	  	@Id    BIGINT=NULL,
	  	@CreatedBy    BIGINT=NULL,
	  	@UpdatedBy    BIGINT=NULL,
		@CreatedOn  DATETIMEOFFSET(7)=NULL,
		@UpdatedOn  DATETIMEOFFSET(7)=NULL,
	  	@IsDeleted    BIT=NULL,
	  	@IsActive    BIT=NULL,
		@RootPath NVARCHAR(MAX)=NULL,
		@UserName NVARCHAR(MAX)=NULL,
		@Password NVARCHAR(MAX)=NULL,
		@Name NVARCHAR(MAX)=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [Directory]
	SET
		 [UpdatedBy] = ISNULL(@UpdatedBy,[UpdatedBy]),
	 [UpdatedOn] = switchoffset(sysdatetimeoffset(),'+00:00'),	
		 [IsDeleted] = ISNULL(@IsDeleted,[IsDeleted]),
		 [IsActive] = ISNULL(@IsActive,[IsActive]),
		 [RootPath] = ISNULL(@RootPath,[RootPath]),
		 [UserName] = ISNULL(@UserName,[UserName]),
		 [Password] = ISNULL(@Password,[Password]),
		 [Name] = ISNULL(@Name,[Name])
	 WHERE
	 (
	  Id=@Id
	 )
END