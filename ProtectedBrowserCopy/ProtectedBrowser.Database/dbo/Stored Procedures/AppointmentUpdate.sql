-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AppointmentUpdate]
	  	@Id						BIGINT=NULL,
	  	@UpdatedBy				BIGINT=NULL,
		@UpdatedOn				DATETIMEOFFSET(7)=NULL,
	  	@IsActive				BIT=NULL,
		@AppointmentDate		DATETIMEOFFSET(7)=NULL,
		@Note					NVARCHAR(MAX)=NULL,
	  	@ToUserId				BIGINT=NULL,
		@FromUserId				BIGINT=NULL,
		@IsCancel				BIT=NULL,
		@CancellationReason		NVARCHAR(MAX)=NULL,
		@StartTime				TIME(7)=NULL,
		@EndTime				TIME(7)=NULL,
		@isAppointmentDone		BIT=NULL,
		@Status					NVARCHAR(50)=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE Appointment
	SET
	 UpdatedBy			= ISNULL(@UpdatedBy,UpdatedBy),	 		
	 UpdatedOn			= switchoffset(sysdatetimeoffset(),'+00:00'),		
	 IsActive			= ISNULL(@IsActive,IsActive),	 		
	 AppointmentDate	= ISNULL(@AppointmentDate,AppointmentDate),	
	 Note				= ISNULL(@Note,Note),	 		
	 ToUserId			= ISNULL(@ToUserId,ToUserId),
	 FromUserId			= ISNULL(@FromUserId,FromUserId),
	 IsCancel			= ISNULL(@IsCancel,IsCancel),
	 CancellationReason = ISNULL(@CancellationReason,CancellationReason),
	 StartTime			= ISNULL(@StartTime,StartTime),
	 EndTime			= ISNULL(@EndTime,EndTime),
	 isAppointmentDone	= ISNULL(@isAppointmentDone,isAppointmentDone),
	 Status				= ISNULL(@Status,Status)	 		
	 WHERE
	 (
	  Id=@Id
	 )
END
