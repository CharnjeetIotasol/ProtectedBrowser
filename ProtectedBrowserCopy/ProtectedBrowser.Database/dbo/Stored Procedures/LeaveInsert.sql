
CREATE PROCEDURE [dbo].[LeaveInsert](

	  	@CreatedBy		BIGINT				=NULL,
		@StartDate		DATETIMEOFFSET(7)	=NULL,
		@EndDate		DATETIMEOFFSET(7)	=NULL,
		@StartTime		TIME(7)				=NULL,
		@EndTime		TIME(7)				=NULL,
		@Type			NVARCHAR(50)		=NULL,
		@Description	NVARCHAR(MAX)		=NULL,
		@UserId			BIGINT					=NULL
)
AS 
BEGIN
SET NOCOUNT ON;
	  INSERT INTO [Leave]
	  (
	   [CreatedBy],[UpdatedBy],[StartDate],[EndDate],[StartTime], [EndTime], [Type], [Description],[UserId]
	  )
	  VALUES
	  ( 
	   @CreatedBy,@CreatedBy,@StartDate,@EndDate, @StartTime, @EndTime, @Type, @Description,@UserId
	  )
	SELECT SCOPE_IDENTITY()
 END
