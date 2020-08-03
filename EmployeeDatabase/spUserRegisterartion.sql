CREATE PROCEDURE [dbo].[spUserRegister] (@FirstName varchar(20),@LastName varchar(20),@Gender varchar(10),
@EmailId varchar(50),@PhoneNumber varchar(10),@City varchar(10),@Password varchar(20))
AS
BEGIN
DECLARE @status int
set @status=0
	IF NOT EXISTS (SELECT * FROM [dbo].[UserDatabase] WHERE [FirstName] = @FirstName AND [LastName] = @LastName AND [EmailId] = @EmailId)
	Begin
		Insert into UserDatabase(FirstName,LastName,Gender,EmailId,PhoneNumber,City,RegistrationDate,Password)
		values(@FirstName,@LastName,@Gender,@EmailId,@PhoneNumber,@City,CURRENT_TIMESTAMP,@Password)
		SELECT Id,FirstName,LastName,Gender,EmailId,PhoneNumber,City,RegistrationDate,Password FROM UserDatabase where EmailId = @EmailId;
	end
	else
	Select @status
END
GO


