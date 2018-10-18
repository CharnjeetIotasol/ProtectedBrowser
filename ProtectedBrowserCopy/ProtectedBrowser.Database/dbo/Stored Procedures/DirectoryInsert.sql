
CREATE PROCEDURE [dbo].[DirectoryInsert](

	  	@CreatedBy    BIGINT=NULL,
	  	@UpdatedBy    BIGINT=NULL,
	  	@IsActive    BIT=NULL,
		@RootPath NVARCHAR(MAX)=NULL,
		@UserName NVARCHAR(MAX)=NULL,
		@Password NVARCHAR(MAX)=NULL,
		@Name NVARCHAR(MAX)=NULL
)
AS 
BEGIN
SET NOCOUNT ON;
	  INSERT INTO [Directory]
	  (
	   [CreatedBy],[UpdatedBy],[IsActive],[RootPath],[UserName],[Password],[Name]
	  )
	  VALUES
	  ( 
	   @CreatedBy,@UpdatedBy,@IsActive,@RootPath,@UserName,@Password,@Name
	  )
	SELECT SCOPE_IDENTITY()
 END