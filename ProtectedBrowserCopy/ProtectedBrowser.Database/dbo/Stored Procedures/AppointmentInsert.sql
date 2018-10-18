
CREATE PROCEDURE [dbo].[AppointmentInsert](

	  	@CreatedBy			BIGINT=NULL,
		@AppointmentDate	DATETIMEOFFSET(7)=NULL,
		@Note				NVARCHAR(MAX)=NULL,
		@StartTime			TIME(7)=NULL,
		@EndTime			TIME(7)=NULL,
		@ToUserId			BIGINT=NULL,
		@FromUserId			BIGINT=NULL,
		@Status				NVARCHAR(50)=NULL
)
AS 
BEGIN
SET NOCOUNT ON;
	  INSERT INTO Appointment
	  (
	   CreatedBy,
	   UpdatedBy,
	   AppointmentDate,
	   Note,
	   StartTime,
	   EndTime,
	   ToUserId,
	   FromUserId,
	   Status
	  )
	  VALUES
	  ( 
	   @CreatedBy,
	   @CreatedBy,
	   @AppointmentDate,
	   @Note,
	   @StartTime,
	   @EndTime,
	   @ToUserId,
	   @FromUserId,
	   @Status
	  )
	SELECT SCOPE_IDENTITY()
 END
