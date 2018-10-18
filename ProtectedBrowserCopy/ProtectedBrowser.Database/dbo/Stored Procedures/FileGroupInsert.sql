
CREATE PROCEDURE [dbo].[FileGroupInsert]
(
	  	@CreatedBy    BIGINT=NULL,
		@Name		NVARCHAR(250)=NULL,
		@Type		NVARCHAR(50)=NULL
)
AS 
BEGIN
SET NOCOUNT ON;
	  INSERT INTO [FileGroup]
	  (
	   CreatedBy,UpdatedBy,Name, [Type]
	  )
	  VALUES
	  ( 
	   @CreatedBy,@CreatedBy,@Name, @Type
	  )
	SELECT SCOPE_IDENTITY()
 END
