CREATE PROCEDURE [dbo].[UpdateUserProfile](
	@UserId          BIGINT = NULL,
	@FirstName       NVARCHAR(100) = NULL,
	@LastName        NVARCHAR(100) = NULL,
	@PhoneNumber     NVARCHAR(30) = NULL,
	@IsActive        BIT = NULL,
	@ProfileImageUrl	NVARCHAR(MAX)=NULL
)
AS
BEGIN
	UPDATE Users SET
	firstName       =     ISNULL(@FirstName,firstName),
	lastName        =     ISNULL(@LastName,lastName),
	PhoneNumber     =     ISNULL(@PhoneNumber,PhoneNumber),
	IsActive       =      ISNULL(@IsActive,IsActive),
	ProfilePic		=		ISNULL(@ProfileImageUrl, ProfilePic) 
WHERE

Id = @UserId

END
