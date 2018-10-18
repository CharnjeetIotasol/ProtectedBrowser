CREATE PROCEDURE [dbo].[SelectUserProfileByUniqueCode]
	@UniqueCode NVARCHAR(65)=NULL
AS
BEGIN
	
	SELECT 
	U.Email,
	U.Id,
	U.IsActive,
	U.PhoneNumber,
	U.UserName,
	U.firstName,
	U.lastName,
	U.ProfilePic,
	U.UniqueCode
	FROM Users U
	WHERE 
	U.IsDeleted=0
	AND
	(
		@UniqueCode IS NULL
		OR
		U.UniqueCode=@UniqueCode
	)
END
