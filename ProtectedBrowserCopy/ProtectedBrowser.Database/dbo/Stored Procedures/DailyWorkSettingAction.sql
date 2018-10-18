
CREATE PROCEDURE [dbo].[DailyWorkSettingAction]
(	
	@Sun				BIT=NULL,
	@Mon				BIT=NULL,
	@Tue				BIT=NULL,
	@Wed				BIT=NULL,
	@Thu				BIT=NULL,
	@Fri				BIT=NULL,
	@Sat				BIT=NULL,
	@StartTime			TIME(7)=NULL,
	@EndTime			TIME(7)=NULL,
	@StartLunchTime		TIME(7)=NULL,
	@EndLunchTime		TIME(7)=NULL,
	@CreatedBy			BIGINT=NULL,
	@Id					INT=NULL
	
)
AS
BEGIN
	SET NOCOUNT OFF;
		BEGIN
		IF(@Id IS NULL)
		BEGIN
			INSERT INTO [dbo].[DailyWorkSetting]
			(			
				[Sunday],
				[Monday],
				[Tuesday],
				[Wednesday],
				[Thursday],
				[Friday],
				[Satureday],
				[StartTime],
				[EndTime],
				[StartLunchTime],
				[EndLunchTime],
				[CreatedBy],
				UpdatedBy
			)
			VALUES 
			(			
				@Sun,
				@Mon,
				@Tue,
				@Wed,
				@Thu,
				@Fri,
				@Sat, 
				@StartTime,  
				@EndTime, 
				@StartLunchTime,
				@EndLunchTime,
				@CreatedBy,
				@CreatedBy
			);
			SELECT CAST (SCOPE_IDENTITY() AS bigint)  AS Id;
		END
		ELSE
		BEGIN
			UPDATE 
				[dbo].[DailyWorkSetting]
			SET 
				[Sunday]			= ISNULL(@Sun, [Sunday]),
				[Monday]			= ISNULL(@Mon, [Monday]),
				[Tuesday]			= ISNULL(@Tue, [Tuesday]),
				[Wednesday]			= ISNULL(@Wed, [Wednesday]),
				[Thursday]			= ISNULL(@Thu, [Thursday]),
				[Friday]			= ISNULL(@Fri, [Friday]),
				[Satureday]			= ISNULL(@Sat, [Satureday]),
				[StartTime]			= ISNULL(@StartTime, [StartTime]),
				[EndTime]			= ISNULL(@EndTime, [EndTime]),
				[StartLunchTime]	= ISNULL(@StartLunchTime, [StartLunchTime]),
				[EndLunchTime]		= ISNULL(@EndLunchTime, [EndLunchTime]),
				[UpdatedDate]		= SYSDATETIMEOFFSET(),
				[UpdatedBy]			= ISNULL(@CreatedBy, UpdatedBy)
			WHERE
			(
				([Id] = @Id)
			)
			SELECT @Id
		END
		END
	End
