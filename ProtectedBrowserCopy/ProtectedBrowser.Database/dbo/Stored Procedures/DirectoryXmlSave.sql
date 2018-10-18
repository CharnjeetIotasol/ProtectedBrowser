CREATE PROCEDURE [dbo].[DirectoryXMLSave]
 @DirectoryXml xml
AS
BEGIN
 -- SET NOCOUNT ON added to prevent extra result sets from
 -- interfering with SELECT statements.
 SET NOCOUNT ON;
 ;WITH XmlData AS 
 (
  SELECT
		NDS.DT.value('(Id)[1]', 'BIGINT') AS 'Id',
		NDS.DT.value('(CreatedBy)[1]', 'BIGINT') AS 'CreatedBy',
		NDS.DT.value('(UpdatedBy)[1]', 'BIGINT') AS 'UpdatedBy',
		NDS.DT.value('(CreatedOn)[1]', 'DATETIMEOFFSET(7)') AS 'CreatedOn',
		NDS.DT.value('(UpdatedOn)[1]', 'DATETIMEOFFSET(7)') AS 'UpdatedOn',
	  	NDS.DT.value('(IsDeleted)[1]', 'BIT') AS 'IsDeleted',
	  	NDS.DT.value('(IsActive)[1]', 'BIT') AS 'IsActive',
		NDS.DT.value('(RootPath)[1]', 'NVARCHAR') AS 'RootPath',
		NDS.DT.value('(UserName)[1]', 'NVARCHAR') AS 'UserName',
		NDS.DT.value('(Password)[1]', 'NVARCHAR') AS 'Password',
		NDS.DT.value('(Name)[1]', 'NVARCHAR') AS 'Name',
  FROM 
	@DirectoryXml.nodes('/root/Directory') AS NDS(DT)
   )
   MERGE INTO Directory R
   USING XmlData x on R.Id=x.Id
   WHEN MATCHED 
   THEN UPDATE SET
    R.CreatedBy =ISNULL(x.CreatedBy ,R.CreatedBy),R.UpdatedBy =ISNULL(x.UpdatedBy ,R.UpdatedBy),R.CreatedOn =ISNULL(x.CreatedOn ,R.CreatedOn),R.UpdatedOn =ISNULL(x.UpdatedOn ,R.UpdatedOn),R.IsDeleted =ISNULL(x.IsDeleted ,R.IsDeleted),R.IsActive =ISNULL(x.IsActive ,R.IsActive),R.RootPath =ISNULL(x.RootPath ,R.RootPath),R.UserName =ISNULL(x.UserName ,R.UserName),R.Password =ISNULL(x.Password ,R.Password),R.Name =ISNULL(x.Name ,R.Name)
  WHEN NOT MATCHED 
  THEN 
    INSERT
    VALUES(
    x.CreatedBy,x.UpdatedBy,x.CreatedOn,x.UpdatedOn,x.IsDeleted,x.IsActive,x.RootPath,x.UserName,x.Password,x.Name
    );
END