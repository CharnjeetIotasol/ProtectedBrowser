CREATE PROCEDURE [dbo].[CategoryInsert](
@CategoryName        NVARCHAR(100)=NULL,
@IsActive           BIT=NULL,
@CreatedBy          BIGINT = NULL
)
AS 
BEGIN
SET NOCOUNT ON;
	  INSERT INTO Category
	  (
	   CategoryName,
	   CreatedBy,
	   IsActive,
	   UpdatedBy
	  
	  )
	  VALUES
	  ( 
	   @CategoryName,
	   @CreatedBy,
	   @IsActive,
	   @CreatedBy
	   
	  )
	SELECT SCOPE_IDENTITY()
 END
