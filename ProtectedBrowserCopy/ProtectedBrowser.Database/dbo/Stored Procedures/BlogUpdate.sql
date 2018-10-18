CREATE PROCEDURE [dbo].[BlogUpdate]
(
@Id BIGINT=NULL,
@Title NVARCHAR(200)=null,
@Description NVARCHAR(max)=null,
@CategoryId BIGINT=NULL,
@IsDeleted  BIT=NULL,
@IsActive   BIT=NULL,
@UpdatedBy  BIGINT=NULL,
@FileId BIGINT=NULL
)
AS BEGIN
SET NOCOUNT ON;
UPDATE Blog SET
	Title = ISNULL(@Title,Title),
	[Description] = ISNULL(@Description,[Description]),
	CategoryId  =ISNULL(@CategoryId,CategoryId),
	FileId  =ISNULL(@FileId,FileId),
	IsDeleted  = ISNULL(@IsDeleted,IsDeleted),
	IsActive  = ISNULL(@IsActive,IsActive),
	UpdatedBy = ISNULL(@UpdatedBy,UpdatedBy),
	UpdatedOn = switchoffset(sysdatetimeoffset(),'+00:00')

	WHERE
	Id = @Id
END
