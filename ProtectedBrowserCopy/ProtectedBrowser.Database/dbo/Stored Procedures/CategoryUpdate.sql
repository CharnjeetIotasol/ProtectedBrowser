-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CategoryUpdate]
	@CategoryId         BIGINT=NULL,
	@CategoryName        NVARCHAR(100)=NULL,
	@IsActive           BIT=NULL,
	@IsDeleted          BIT=NULL,
	@UpdatedBy          BIGINT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE Category
	SET
	 CategoryName = ISNULL(@CategoryName,CategoryName),
	 UpdatedOn = SYSUTCDATETIME(),
	 IsActive =  ISNULL(@IsActive,IsActive),
	 IsDeleted = ISNULL(@IsDeleted ,IsDeleted ),
	 UpdatedBy = ISNULL(@UpdatedBy,UpdatedBy)
	 WHERE
	 (
	  Id=@CategoryId
	 )
END
