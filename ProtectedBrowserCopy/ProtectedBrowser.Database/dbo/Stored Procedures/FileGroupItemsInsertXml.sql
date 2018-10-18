
CREATE PROCEDURE [dbo].[FileGroupItemsInsertXml](
	@UserId			BIGINT = NULL,
	@TypeId		BIGINT=NULL,
	@FileGroupItemsXml XML = NULL
)
AS 
BEGIN
	SET NOCOUNT ON;
	DECLARE @FileGroupItems XML = NULL;
	SET @FileGroupItems = @FileGroupItemsXml;
	;WITH XmlData AS 
	(
		SELECT
			FileGroupItemsXml.DT.value('(Id)[1]', 'BIGINT') AS 'Id',
			FileGroupItemsXml.DT.value('(Filename)[1]', 'nvarchar(256)') AS 'Filename',
			FileGroupItemsXml.DT.value('(MimeType)[1]', 'nvarchar(256)') AS 'MimeType',
			FileGroupItemsXml.DT.value('(Thumbnail)[1]', 'nvarchar(256)') AS 'Thumbnail',
			FileGroupItemsXml.DT.value('(Size)[1]', 'BIGINT') AS 'Size',
			FileGroupItemsXml.DT.value('(Path)[1]', 'nvarchar(256)') AS 'Path',
			FileGroupItemsXml.DT.value('(OriginalName)[1]', 'nvarchar(256)') AS 'OriginalName',
			FileGroupItemsXml.DT.value('(OnServer)[1]', 'nvarchar(256)') AS 'OnServer',
			FileGroupItemsXml.DT.value('(Type)[1]', 'nvarchar(50)') AS 'Type'
		FROM 
        @FileGroupItems.nodes('/ArrayOfFileGroupItemsModel/FileGroupItemsModel') AS FileGroupItemsXml(DT)
	 )
	 MERGE INTO FileGroupItems AF
	 USING XmlData x on AF.Id=x.Id
	 WHEN MATCHED 
		THEN UPDATE SET
			AF.UpdatedBy = @UserId,
			AF.Filename = x.Filename,
			AF.MimeType = x.MimeType,
			AF.Thumbnail = x.Thumbnail,
			AF.Size = x.Size,
			AF.Path = x.Path,
			AF.OriginalName = x.OriginalName,
			AF.OnServer = x.OnServer,
			AF.TypeId = @TypeId,
			AF.Type=x.Type
		
	WHEN NOT MATCHED 
	THEN 
	
      INSERT
	  (
	   CreatedBy,UpdatedBy,Filename,MimeType,Thumbnail,Size,Path,OriginalName,OnServer,TypeId, [Type]
	  )
      VALUES
	  ( 
	   @UserId,@UserId,x.Filename,x.MimeType,x.Thumbnail,x.Size,x.Path,x.OriginalName,x.OnServer,@TypeId, x.Type 
	  );
END
