-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EmailConfigurationSelect]
	@ConfigurationKey NVARCHAR(200)=NULL
AS
BEGIN
	SELECT * FROM EmailConfiguration WHERE ConfigurationKey=@ConfigurationKey AND IsDeleted=0
END
