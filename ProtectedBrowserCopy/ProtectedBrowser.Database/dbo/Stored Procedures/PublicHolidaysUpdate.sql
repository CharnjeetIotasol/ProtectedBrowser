-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PublicHolidaysUpdate]
(	
	@StartHoliday	DATETIMEOFFSET(7),
	@EndHoliday		DATETIMEOFFSET(7),
	@Description	NVARCHAR(500) = Null,
	@UpdatedBy		BIGINT=NULL,
	@IsDeleted		BIT=NULL,
	@Id				BIGINT=NULL
	
)
AS
BEGIN
	SET NOCOUNT OFF;
		UPDATE PublicHolidays SET
		StartHoliday=ISNULL(@StartHoliday, StartHoliday),
		EndHoliday=ISNULL(@EndHoliday,EndHoliday),
		Description=ISNULL(@Description, Description),
		UpdatedBy=ISNULL(@UpdatedBy, UpdatedBy),
		UpdatedDate=(switchoffset(sysdatetimeoffset(),'+00:00')),
		IsDeleted=ISNULL(@IsDeleted, IsDeleted)
		WHERE 
		Id=@Id
End
