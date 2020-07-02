using System;
using EmployeeBuisenessLayer.Interface;
using EmployeeBuisenessLayer.Services;
using EmployeeManagement.Controllers;
using EmployeeRepositoryLayer.Interface;
using EmployeeRepositoryLayer.Services;
using Xunit;

namespace EmployeeManagementTestCases
{
    public class EmployeeTest
    {
        EmployeeController employeeController;
        IEmployeeBuiseness employeeBuiseness;
        IEmployeeRepository employeeRepository;

        public EmployeeTest()
        {
            employeeRepository = new EmployeeRepository();
            employeeBuiseness = new EmployeeBuiseness(employeeRepository);
            employeeController = new EmployeeController(employeeBuiseness);
        }
        [Fact]
        public void Test1()
        {

        }
    }
}
