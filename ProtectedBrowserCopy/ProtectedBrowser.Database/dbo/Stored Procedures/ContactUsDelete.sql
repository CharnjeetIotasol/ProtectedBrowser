CREATE PROCEDURE [dbo].[ContactUsDelete]
(
	@Id   BIGINT=NULL
	
)
AS BEGIN
SET NOCOUNT ON;
	UPDATE ContactUs SET
	IsDeleted = 1
WHERE
	Id = @Id
END
