-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LeaveUpdate]
	  	@Id				BIGINT=NULL,
	  	@UpdatedBy		BIGINT=NULL,
		@UpdatedOn		DATETIMEOFFSET(7)=NULL,
	  	@IsDeleted		BIT=NULL,
	  	@IsActive		BIT=NULL,
		@StartDate		DATETIMEOFFSET(7)=NULL,
		@EndDate		DATETIMEOFFSET(7)=NULL,
		@StartTime		Time(7)=NULL,
		@EndTime		Time(7)=NULL,
		@Type			NVARCHAR(20)=NULL,
		@Description	NVARCHAR(MAX)=NULL,
		@UserId			BIGINT=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [Leave]
	SET
	 [UpdatedBy] = ISNULL(@UpdatedBy,[UpdatedBy]),	 		
	 [UpdatedOn] = switchoffset(sysdatetimeoffset(),'+00:00'),	
	 [IsDeleted] = ISNULL(@IsDeleted,[IsDeleted]),	 		
	 [IsActive] = ISNULL(@IsActive,[IsActive]),	 		
	 [StartDate] = ISNULL(@StartDate,[StartDate]),	 		
	 [EndDate] = ISNULL(@EndDate,[EndDate]),	 		
	 [StartTime] = ISNULL(@StartTime,[StartTime]),	 		
	 [EndTime] = ISNULL(@EndTime,[EndTime]),	 		
	 [Type] = ISNULL(@Type,[Type]),	 		
	 [Description] = ISNULL(@Description,[Description]),	 		
	 [UserId] = ISNULL(@UserId,[UserId])	 		
	 WHERE
	 (
	  Id=@Id
	 )
END
