-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.FileGroupItemInsert
	@CreatedBy		BIGINT=NULL,
	@FileName		NVARCHAR(250)=NULL,
	@MimeType		NVARCHAR(250)=NULL,
	@Thumbnail		NVARCHAR(250)=NULL,
	@Size			BIGINT=NULL,
	@Path			NVARCHAR(250)=NULL,
	@OriginalName	NVARCHAR(250)=NULL,
	@OnServer		NVARCHAR(250)=NULL,
	@TypeId			BIGINT=NULL,
	@Type			NVARCHAR(50)=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	INSERT INTO FileGroupItems
	(
		CreatedBy,
		UpdatedBy,		
		FileName,		
		MimeType,		
		Thumbnail,		
		Size,			
		Path,			
		OriginalName,	
		OnServer,		
		TypeId,			
		Type			
	)
	VALUES
	(
		@CreatedBy,
		@CreatedBy,		
		@FileName,		
		@MimeType,		
		@Thumbnail,	
		@Size,			
		@Path,			
		@OriginalName,	
		@OnServer,		
		@TypeId,			
		@Type			
	)
	SELECT SCOPE_IDENTITY()
END
