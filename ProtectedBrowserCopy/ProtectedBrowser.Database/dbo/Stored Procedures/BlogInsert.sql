CREATE PROCEDURE [dbo].[BlogInsert]
(
@Title NVARCHAR(200),
@Description NVARCHAR(max),
@CategoryId BIGINT=NULL,
@IsActive BIT =NULL,
@CreatedBy  BIGINT=NULL,
@FileId  BIGINT=NULL

)
AS BEGIN
SET NOCOUNT ON;
INSERT INTO Blog

(
	Title,
	[Description],
	CategoryId,
	IsActive,
	CreatedBy,
	UpdatedBy,
	FileId

)
VALUES
(
	@Title,
	@Description,
	@CategoryId,
	@IsActive,
	@CreatedBy,
	@CreatedBy,
	@FileId

)

SELECT @@IDENTITY
END
