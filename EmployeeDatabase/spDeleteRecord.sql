CREATE PROCEDURE [dbo].[spDeleteRecord] (@EmployeeId int)
AS
BEGIN
DECLARE @status int
set @status=0
	if EXISTS(select * from EmployeeDatabase where EmployeeId = @EmployeeId)
	begin
		select * from EmployeeDatabase WHERE EmployeeId = @EmployeeId;
		DELETE FROM EmployeeDatabase WHERE EmployeeId = @EmployeeId;
	end
	else
		select @status
END
GO


