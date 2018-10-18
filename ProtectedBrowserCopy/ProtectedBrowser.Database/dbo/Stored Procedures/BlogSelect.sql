CREATE PROCEDURE [dbo].[BlogSelect]
(
	@Id  BIGINT=NULL,
	@IsActive BIT=NULL,
	@CategoryId BIGINT=NULL,
	@next int = NULL,
	@offset int = NULL
)

AS BEGIN
DECLARE 
@IdTemp	 BIGINT =@Id,
@IsActiveTemp bit = @IsActive,
@nextTemp int = @next,
@offsetTemp int = @offset

IF @nextTemp IS NULL
BEGIN
SET @nextTemp =100000
SET @offsetTemp=1
END
SET NOCOUNT ON;
SELECT 
B.Id,
B.Title,
B.[Description],
B.CategoryId,
B.IsActive,
B.CreatedOn,
B.CreatedBy,
B.UpdatedOn,
B.UpdatedBy,
C.CategoryName,
overall_count = COUNT(1) OVER(),
UF.Id as FileId,
UF.FileName,
UF.FileUrl 

FROM Blog B 
LEFT JOIN UploadedFile UF on UF.Id=B.FileId
LEFT JOIN Category C ON
	B.CategoryId =C.Id 

WHERE 
B.IsDeleted = 0
AND
(
	@Id IS NULL
		OR
	B.Id = @Id
)
AND
(
	@IsActive IS NULL
		OR
	B.IsActive = @IsActive
)

AND
(
	@CategoryId IS NULL
		OR
	B.CategoryId= @CategoryId
)

Order by B.CreatedOn desc
OFFSET (@nextTemp*@offsetTemp)-@nextTemp ROWS
    FETCH NEXT @nextTemp ROWS ONLY
END



alter table blog 
alter column categoryid BIGINT NULL
