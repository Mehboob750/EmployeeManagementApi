CREATE PROCEDURE [dbo].[spUserLogin](@EmailId varchar(50),@Password varchar(20)) 
AS
BEGIN
DECLARE @Status int
set @Status=0
IF EXISTS(SELECT * FROM UserDatabase WHERE EmailId = @EmailId AND Password = @Password)
   SELECT Id,FirstName,LastName,Gender,EmailId,PhoneNumber,City,RegistrationDate FROM UserDatabase WHERE EmailId = @EmailId AND Password = @Password
ELSE
	Select @Status
END
GO


