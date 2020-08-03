CREATE PROCEDURE [dbo].[spForgetPassword](@EmailId varchar(50))
AS
BEGIN
DECLARE @status int
set @status=0
IF EXISTS(SELECT * FROM UserDatabase WHERE EmailId = @EmailId)
	select Id, EmailId from UserDatabase where EmailId=@EmailId
else
	select @status
END
GO


