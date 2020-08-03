CREATE PROCEDURE [dbo].[spResetPassword](@EmailId varchar(50),@NewPassword varchar(20))
AS
BEGIN
DECLARE @status int
set @status=0
if EXISTS(select * from UserDatabase where EmailId = @EmailId)
	Update UserDatabase set Password=@NewPassword where EmailId=@EmailId
else
	select @status
END
GO


