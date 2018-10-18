-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PublicHolidaysInsert]
(	
	@StartHoliday	DATETIMEOFFSET(7),
	@EndHoliday	DATETIMEOFFSET(7),
	@Description	NVARCHAR(500) = Null,
	@CreatedBy		BIGINT=NULL
)
AS
BEGIN
	SET NOCOUNT OFF;
		INSERT INTO [dbo].[PublicHolidays]
		(			
			StartHoliday,
			EndHoliday,
			[Description],
			[CreatedBy],
			[UpdatedBy]
		)
		VALUES 
		(			
			@StartHoliday,
			@EndHoliday, 
			@Description, 
			@CreatedBy,
			@CreatedBy
		);
		SELECT SCOPE_IDENTITY()
	End
