
CREATE PROCEDURE [dbo].[UploadedFileInsert]
(
@FileName NVARCHAR(250),
@FileUrl NVARCHAR(max)

)
AS BEGIN
SET NOCOUNT ON;
INSERT INTO UploadedFile

(
	FileName,
	FileUrl,
	IsDeleted,
	CreatedOn

)
VALUES
(
	@FileName,
	@FileUrl,
	0,
	switchoffset(sysdatetimeoffset(),'+00:00')

)

SELECT @@IDENTITY
END
