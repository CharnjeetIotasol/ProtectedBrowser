-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DummyTableForFileUpdate]
	@Name			NVARCHAR(100)=NULL,
	@UpdatedBy		BIGINT=NULL,
	@IsDeleted		BIT=NULL,
	@IsActive		BIT=NULL,
	@Id				BIGINT=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE DummyTableForFile SET
	Name=ISNULL(@Name, Name),
	IsDeleted=ISNULL(@IsDeleted, IsDeleted),
	IsActive=ISNULL(@IsActive, IsActive),
	UpdatedBy=ISNULL(@UpdatedBy, UpdatedBy),
	UpdatedOn=switchoffset(sysdatetimeoffset(),'+00:00')
	WHERE 
	Id=@Id
END
