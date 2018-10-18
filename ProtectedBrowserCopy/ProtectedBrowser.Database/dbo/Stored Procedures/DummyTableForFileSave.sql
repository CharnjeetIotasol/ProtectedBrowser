-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DummyTableForFileSave]
	@Name			NVARCHAR(100)=NULL,
	@CreatedBy		BIGINT=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO DummyTableForFile
	(
		Name,
		CreatedBy,
		UpdatedBy
	)
	VALUES
	(
		@Name,
		@CreatedBy,
		@CreatedBy
	)
	SELECT SCOPE_IDENTITY()
END
