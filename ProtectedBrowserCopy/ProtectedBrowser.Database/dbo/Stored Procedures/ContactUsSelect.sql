CREATE PROCEDURE [dbo].[ContactUsSelect]
(
	@Id  BIGINT=NULL,
	@next INT = NULL,
	@offset INT = NULL
)
AS BEGIN
DECLARE 
@IdTemp	 BIGINT =@Id,
@nextTemp int = @next,
@offsetTemp int = @offset

IF @nextTemp IS NULL
BEGIN
SET @nextTemp =100000
SET @offsetTemp=1
END
SET NOCOUNT ON;
SELECT
	Id,
	Name,
	EmailAddress,
	PhoneNumber,
	CreatedOn,
	[Message]
FROM ContactUs
WHERE
	(
		@Id IS NULL
			OR
		Id = @Id
	)
	AND
	IsDeleted = 0
Order by CreatedOn desc
OFFSET (@nextTemp*@offsetTemp)-@nextTemp ROWS
    FETCH NEXT @nextTemp ROWS ONLY
END
