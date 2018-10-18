CREATE PROCEDURE [dbo].[ContactUsInsert]
(
	@Name          NVARCHAR(100)=NULL,
	@PhoneNumber   NVARCHAR(25)=NULL,
	@EmailAddress  NVARCHAR(100)=NULL,
	@Message       NVARCHAR(MAX)=NULL
)
AS BEGIN
SET NOCOUNT ON;
	INSERT INTO ContactUs
	(
		Name,
		PhoneNumber,
		EmailAddress,
		[Message]
	)
	VALUES
	(
		@Name,
		@PhoneNumber,
		@EmailAddress,
		@Message
	)
END
