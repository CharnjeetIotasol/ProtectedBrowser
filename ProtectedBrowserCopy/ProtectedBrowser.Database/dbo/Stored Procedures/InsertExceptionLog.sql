/****** created by = kunal gupta ******/
/****** created date = 06-06-2017 ******/

CREATE PROCEDURE InsertExceptionLog(
	@Source        NVARCHAR(1000)=NULL,
	@Message       Nvarchar(1000)=NULL,
	@StackTrace    NVARCHAR(MAX)=NULL,
	@Uri           NVARCHAR(1000)=NULL,
	@method        NVARCHAR(50)=NULL,
	@CreatedBy     BIGINT=NULL
)
AS BEGIN
	INSERT INTO ExceptionLog
	(
		Source,
		Message,
		StackTrace,
		Uri,
		method,
		CreatedBy

	)
	Values
	(
		@Source,
		@Message,
		@StackTrace,
		@Uri,
		@method,
		@CreatedBy
	)
	SELECT SCOPE_IDENTITY()
END
