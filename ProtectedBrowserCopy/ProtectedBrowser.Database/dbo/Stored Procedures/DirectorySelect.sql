CREATE PROCEDURE [dbo].[DirectorySelect](
@Id	        BIGINT =NULL,
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
	 		R.[Id]
	 	,
	 		R.[CreatedBy]
	 	,
	 		R.[UpdatedBy]
	 	,
	 		R.[CreatedOn]
	 	,
	 		R.[UpdatedOn]
	 	,
	 		R.[IsDeleted]
	 	,
	 		R.[IsActive]
	 	,
	 		R.[RootPath]
	 	,
	 		R.[UserName]
	 	,
	 		R.[Password]
	 	,
	 		R.[Name]
	 	,
	overall_count = COUNT(*) OVER()
	FROM [Directory] R  
	 		
	WHERE 
	(
		@Id IS NULL
		OR
		R.Id = @Id
	)
	AND
	(
		@IsActive IS NULL
			OR
		R.IsActive = @IsActive
	)
	AND
	(
		R.IsDeleted = 0
	)

	Order by R.Id desc
	OFFSET (@next*@offset)-@next ROWS
    FETCH NEXT @next ROWS ONLY

END
