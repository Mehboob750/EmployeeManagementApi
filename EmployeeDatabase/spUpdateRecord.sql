ALTER procedure [dbo].[spUpdateRecord]
(@EmployeeId int,@FirstName varchar(20),@LastName varchar(20),@Gender varchar(10),@EmailId varchar(50),@PhoneNumber varchar(10),@City varchar(10))
As
BEGIN  
DECLARE @status int
set @status=0
BEGIN TRY 
	if EXISTS(select * from EmployeeDatabase where EmployeeId = @EmployeeId)
	begin
		UPDATE dbo.EmployeeDatabase  
		SET	FirstName = @FirstName,LastName = @LastName,Gender = @Gender,EmailId = @EmailId,PhoneNumber = @PhoneNumber,City = @City,UpdationDate = CURRENT_TIMESTAMP
		WHERE  EmployeeId = @EmployeeId
		SELECT EmployeeId,FirstName,LastName,Gender,EmailId,PhoneNumber,City,RegistrationDate,UpdationDate FROM EmployeeDatabase where EmployeeId = @EmployeeId;
	end
	else
		select @status
END TRY
BEGIN CATCH  
    SELECT ERROR_MESSAGE() AS ErrorMessage;  
END CATCH;
END