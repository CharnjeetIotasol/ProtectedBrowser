CREATE PROCEDURE [dbo].[LeaveSelect] (
@Id	        BIGINT =NULL,
@userId BIGINT = NULL,
@AppointmentDate DATETIMEOFFSET(7)=NULL,
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
 	R.[Id],
	R.[CreatedBy],
	R.[UpdatedBy],
	R.[CreatedOn],
	R.[UpdatedOn],
	R.[IsDeleted],
	R.[IsActive],
	R.[StartDate],
	R.[EndDate],
	R.[StartTime],
	R.[EndTime],
	R.[Type],
	R.[Description],
	R.[UserId],
	U.FirstName,
	U.LastName,
	FullName=U.FirstName+' '+U.LastName,
	overall_count = COUNT(*) OVER()
	FROM [Leave] R  INNER JOIN Users U ON R.UserId=U.Id
	WHERE 
	(
		@Id IS NULL
		OR
		R.Id = @Id
	)
	AND
	(
		@userId IS NULL
		OR
		R.UserId = @userId
	)
	AND
	(
		R.IsDeleted = 0
	)
	AND
	(
		@AppointmentDate IS NULL
		OR
		CONVERT(date, @AppointmentDate) between CONVERT(date, R.StartDate) AND CONVERT(date, R.EndDate)
	)
	Order by R.Id desc
	OFFSET (@next*@offset)-@next ROWS
    FETCH NEXT @next ROWS ONLY

END
