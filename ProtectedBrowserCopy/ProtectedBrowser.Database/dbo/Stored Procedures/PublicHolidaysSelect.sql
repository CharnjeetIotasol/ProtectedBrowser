-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PublicHolidaysSelect]
(	
	@Id				BIGINT=NULL,
	@TodayDate		DATETIMEOFFSET(7)=NULL,
	@StartDate		DATETIMEOFFSET(7)=NULL,
	@EndDate		DATETIMEOFFSET(7)=NULL
)
AS
BEGIN
	SET NOCOUNT OFF;
		SELECT 
		P.Id,
		P.StartHoliday,
		P.EndHoliday,
		P.Description,
		P.IsDeleted,
		P.CreatedBy,
		P.UpdatedBy,
		P.CreatedDate,
		P.UpdatedDate,
		IsOnlyView=(CASE WHEN P.StartHoliday <= @TodayDate THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END)
		FROM PublicHolidays P 
		WHERE
		(
			@Id IS NULL
			OR
			P.Id=@Id
		)
		AND
		(
			@StartDate IS NULL
			OR
			CONVERT(date, P.StartHoliday) BETWEEN CONVERT(date, @StartDate)  AND CONVERT(date, @EndDate)
		)
		AND P.IsDeleted=0
		ORDER BY P.StartHoliday DESC
	End
