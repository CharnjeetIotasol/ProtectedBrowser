CREATE PROCEDURE [dbo].[CategorySelect](
@CategoryId	        BIGINT =NULL,
@IsActive bit = NULL,
@next int = NULL,
@offset int = NULL
)
AS BEGIN

IF @next IS NULL
BEGIN
SET @next =100000
SET @offset=1
END

 SELECT
	C.Id,
	C.CategoryName as Name,
	C.CreatedBy, 
	C.IsActive,
	C.CreatedOn,
	C.UpdatedOn,
	C.UpdatedBy,
	overall_count = COUNT(*) OVER()
	FROM Category C  
	WHERE 
	(
		@CategoryId IS NULL
		OR
		C.Id = @CategoryId
	)
	AND
	(
		@IsActive IS NULL
			OR
		IsActive = @IsActive
	)
	AND
	(
		C.IsDeleted = 0
	)

	Order by Id desc
	OFFSET (@next*@offset)-@next ROWS
    FETCH NEXT @next ROWS ONLY

END
