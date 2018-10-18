CREATE PROCEDURE [dbo].[AppointmentSelect](
@Id         BIGINT =NULL,
@ToUserId	BIGINT=NULL,
@FromUserId	BIGINT=NULL,
@AppointmentDate  DATETIMEOFFSET(7)=NULL,
@StartDate DATETIMEOFFSET(7)=NULL,
@EndDate DATETIMEOFFSET(7)=NULL,
@next int = NULL,
@offset int = NULL
)
AS BEGIN

SET NOCOUNT ON;
IF @next IS NULL
BEGIN
SET @next =100000
SET @offset=1
END

;WITH AppointmentCTE AS(
	 SELECT 
	AP.Id,
	AP.CreatedBy,
	AP.UpdatedBy,
	AP.CreatedOn,
	AP.UpdatedOn,
	AP.IsDeleted,
	AP.IsActive,
	AP.AppointmentDate,
	AP.Note,
	AP.ToUserId,
	AP.FromUserId,
	AP.IsCancel,
	AP.CancellationReason,
	AP.StartTime,
	AP.EndTime,
	AP.isAppointmentDone,
	AP.Status,
	overall_count= COUNT(*) OVER()
	FROM Appointment AP
	WHERE  
	  (
	   @Id IS NULL
	   OR
	   AP.Id=@Id
	  ) 
	  AND
	  (
	   AP.IsDeleted=0
	  ) 
	  AND
	  (
	   AP.IsCancel=0
	  )
	  AND
	  (
		@FromUserId IS NULL
		OR
		AP.FromUserId=@FromUserId
	  )
	  AND
	  (
		@ToUserId IS NULL
		OR
		AP.ToUserId=@ToUserId
	  )
	  AND
	  (
		@AppointmentDate IS NULL
		OR
		CAST(AP.AppointmentDate as date) = CAST(@AppointmentDate as date)
	  )
	  AND
	  (
		  @StartDate IS NULL
		  OR
		  CONVERT(date, AP.AppointmentDate) BETWEEN CONVERT(date, @StartDate) AND CONVERT(date, @EndDate) 
	  )
	 Order by AP.AppointmentDate desc
	 OFFSET (@next*@offset)-@next ROWS
	 FETCH NEXT @next ROWS ONLY
 )

 SELECT 
	CTE.Id,
	CTE.CreatedBy,
	CTE.UpdatedBy,
	CTE.CreatedOn,
	CTE.UpdatedOn,
	CTE.IsDeleted,
	CTE.IsActive,
	CTE.AppointmentDate,
	CTE.Note,
	CTE.ToUserId,
	CTE.FromUserId,
	CTE.IsCancel,
	CTE.CancellationReason,
	CTE.StartTime,
	CTE.EndTime,
	CTE.isAppointmentDone,
	CTE.Status,
	CTE.overall_count,
	US.FirstName AS FromUserFirstName,
	US.LastName AS FromUserLastName,
	US.Email AS FromUserEmail,
	US.PhoneNumber AS FromUserPhoneNumber,
	TU.FirstName AS ToUserFirstName,
	TU.LastName AS ToUserLastName,
	TU.Email AS ToUserEmail,
	TU.PhoneNumber AS ToUserPhoneNumber,
	UP.FirstName AS UpdatedByFirstName,
	UP.LastName AS UpdatedByLastName,
	UP.PhoneNumber AS UpdatedByPhoneNumber,
	UC.FirstName AS CreatedByFirstName,
	UC.LastName AS  CreatedByLastName,
	UC.PhoneNumber AS  CreatedByPhoneNumber 
 FROM AppointmentCTE CTE
	LEFT JOIN Users US ON CTE.FromUserId=US.Id
	LEFT JOIN Users TU ON CTE.ToUserId=TU.Id
	LEFT JOIN Users UP ON CTE.UpdatedBy = UP.Id
	LEFT JOIN Users UC ON CTE.CreatedBy = UC.Id


END
