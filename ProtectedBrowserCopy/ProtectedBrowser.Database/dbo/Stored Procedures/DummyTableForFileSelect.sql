-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DummyTableForFileSelect]
	@Id		BIGINT=NULL,
	@Type	NVARCHAR(50)=NULL,
	@next int = NULL,
	@offset int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF @next IS NULL
	BEGIN
		SET @next =100000
		SET @offset=1
	END

	SELECT 
	D.Id,
	D.Name,
	D.IsActive,
	D.CreatedBy,
	D.UpdatedBy,
	FileGroupItemsXml=(
		SELECT 
			FG.Id,
			FG.CreatedBy,
			FG.UpdatedBy,
			FG.CreatedOn,
			FG.UpdatedOn,
			FG.IsDeleted,
			FG.IsActive,
			FG.Filename,
			FG.MimeType,
			FG.Thumbnail,
			FG.Size,
			FG.Path,
			FG.OriginalName,
			FG.OnServer,
			FG.TypeId,
			FG.Type
			FROM FileGroupItems FG
			WHERE FG.TypeId = D.Id AND FG.Type=@Type AND FG.IsActive = 1 AND FG.IsDeleted = 0
			FOR XML AUTO,ROOT,ELEMENTs
	),
	UP.FirstName AS UpdatedByFirstName,
	UP.LastName AS UpdatedByLastName,
	UP.PhoneNumber AS UpdatedByPhoneNumber,
	UC.FirstName AS CreatedByFirstName,
	UC.LastName AS  CreatedByLastName,
	UC.PhoneNumber AS  CreatedByPhoneNumber
	FROM 
	DummyTableForFile D
	LEFT JOIN Users UP ON D.UpdatedBy = UP.Id
	LEFT JOIN Users UC ON D.CreatedBy = UC.Id
	WHERE
	(
		@Id IS NULL
		OR
		D.Id = @Id
	)
	Order by D.Id desc
	OFFSET (@next*@offset)-@next ROWS
    FETCH NEXT @next ROWS ONLY
END
