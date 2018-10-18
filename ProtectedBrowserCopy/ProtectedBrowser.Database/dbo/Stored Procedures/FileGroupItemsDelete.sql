-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FileGroupItemsDelete]
	@Id			BIGINT=NULL,
	@UpdatedBy	BIGINT=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SET NOCOUNT ON;
   UPDATE FileGroupItems 
   SET 
   IsDeleted=1,
   UpdatedBy=@UpdatedBy,
   UpdatedOn=switchoffset(sysdatetimeoffset(),'+00:00')
   WHERE  
   Id=@Id
END
