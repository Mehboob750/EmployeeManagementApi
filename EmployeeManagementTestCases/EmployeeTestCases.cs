//-----------------------------------------------------------------------
// <copyright file="EmployeeTestCases.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace EmployeeManagementTestCases
{
    using System;
    using EmployeeBuisenessLayer.Interface;
    using EmployeeBuisenessLayer.Services;
    using EmployeeCommonLayer;
    using EmployeeCommonLayer.RequestModel;
    using EmployeeManagement.Controllers;
    using EmployeeRepositoryLayer.Interface;
    using EmployeeRepositoryLayer.Services;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;

    /// <summary>
    /// This class contains the testcases of Employee
    /// </summary>
    public class EmployeeTestCases
    {
        /// <summary>
        /// Created Reference of EmployeeController
        /// </summary>
        EmployeeController employeeController;

        /// <summary>
        /// Created Reference of IEmployeeBL
        /// </summary>
        IEmployeeBL employeeBuiseness;

        /// <summary>
        /// Created Reference of IEmployeeRL
        /// </summary>
        IEmployeeRL employeeRepository;

        /// <summary>
        /// Default constructor used to create new objects
        /// </summary>
        public EmployeeTestCases()
        {
            employeeRepository = new EmployeeRL();
            employeeBuiseness = new EmployeeBL(employeeRepository);
            employeeController = new EmployeeController(employeeBuiseness);
        }

        /// <summary>
        /// Given Employee Request Model check for not Null
        /// </summary>
        [Fact]
        public void GivenEmployeeRequestModel_WhenCheckForNotNull_ShouldReturn()
        {
              EmployeeRequestModel employeeModel = new EmployeeRequestModel();
                employeeModel.FirstName = "Javid";
                employeeModel.LastName = "Shaikh";
                employeeModel.Gender = "male";
                employeeModel.EmailId = "javid@gmail.com";
                employeeModel.PhoneNumber = "7878544502";
                employeeModel.City = "Mumbai";

                Assert.NotNull(employeeModel);
        }

        /// <summary>
        /// Given EmployeeRequestModel Added Returns OkResult 
        /// </summary>
        [Fact]
        public void GivenEmployeeRequestModel_WhenCalledAddEmployee_ShouldReturnOkResult()
        {
            try
            {
                EmployeeRequestModel employeeModel = new EmployeeRequestModel();
                employeeModel.FirstName = "Javid";
                employeeModel.LastName = "Shaikh";
                employeeModel.Gender = "male";
                employeeModel.EmailId = "javid12@gmail.com";
                employeeModel.PhoneNumber = "7888544502";
                employeeModel.City = "Mumbai";
                Assert.NotNull(employeeModel);
                var response = employeeController.AddEmployee(employeeModel);
                Assert.IsType<OkObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<BadRequestObjectResult>(exception);
            }
        }

        /// <summary>
        /// Given Empty strings Added Returns Bad Object Result 
        /// </summary>
        [Fact]
        public void GivenEmployeeRequestModel_WhenEmptyStringFields_ShouldReturnBadRequestObjectResult()
        {
            try
            {

                EmployeeRequestModel employeeModel = new EmployeeRequestModel();
                employeeModel.FirstName = "";
                employeeModel.LastName = "";
                employeeModel.Gender = "";
                employeeModel.EmailId = "";
                employeeModel.PhoneNumber = "";
                employeeModel.City = "";
                var response = employeeController.AddEmployee(employeeModel);
                Assert.IsType<BadRequestObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Given null strings Added Returns Bad Object Result 
        /// </summary>
        [Fact]
        public void GivenEmployeeRequestModel_WhenNullPass_ShouldReturnBadRequestObjectResult()
        {
            try
            {
                EmployeeRequestModel employeeModel = new EmployeeRequestModel();
                employeeModel.FirstName = "Javid";
                employeeModel.LastName = "Shaikh";
                employeeModel.Gender = "male";
                employeeModel.EmailId = null;
                employeeModel.PhoneNumber = "1237450000";
                employeeModel.City = "Pune";

                var response = employeeController.AddEmployee(employeeModel);
                Assert.IsType<BadRequestObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Read All Employee Method used it returns Ok Result
        /// </summary>
        [Fact]
        public void GivenController_WhenReadEmployeeCalled_ShouldReturnOkResult()
        {
            try
            {
                var response = employeeController.ReadEmployee();
                Assert.IsType<OkObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Given Employee Id and Data Update Method is Used it Returns Ok Result
        /// </summary>
        [Fact]
        public void GivenEmployeeRequestModel_WhenCalledUpdateEmployee_ShouldReturnOkResult()
        {
            try
            {
                int EmployeeId = 49;
                EmployeeRequestModel employeeModel = new EmployeeRequestModel();
                employeeModel.FirstName = "Vijay";
                employeeModel.LastName = "Shriwastav";
                employeeModel.Gender = "male";
                employeeModel.EmailId = "vijay@gmail.com";
                employeeModel.PhoneNumber = "9889855800";
                employeeModel.City = "Pune";
                var response = employeeController.UpdateEmployee(EmployeeId,employeeModel);
                Assert.IsType<OkObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Given Wrong Employee Id and Data Update Method is Used it Returns Bad Request Object Result
        /// </summary>
        [Fact]
        public void GivenWrongEmployeeId_WhenCalledUpdateEmployee_ShouldReturnBadRequestObjectResult()
        {
            try
            {
                int EmployeeId = 48;
                EmployeeRequestModel employeeModel = new EmployeeRequestModel();
                employeeModel.FirstName = "Vijay";
                employeeModel.LastName = "Shriwastav";
                employeeModel.Gender = "male";
                employeeModel.EmailId = "vijay@gmail.com";
                employeeModel.PhoneNumber = "9889855800";
                employeeModel.City = "Pune";
                var response = employeeController.UpdateEmployee(EmployeeId, employeeModel);
                Assert.IsType<BadRequestObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Given Employee Id Delete Method is Used it Returns Ok Result
        /// </summary>
        [Fact]
        public void GivenEmployeeId_WhenCalledDeleteEmployee_ShouldReturnOkResult()
        {
            try
            {
                int EmployeeId = 25;
                var response = employeeController.DeleteEmployee(EmployeeId);
                Assert.IsType<OkObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Given Wrong Employee Id Delete Method is Used it Returns Bad Request Obejct Result
        /// </summary>
        [Fact]
        public void GivenWrongEmployeeId_WhenCalledDeleteEmployee_ShouldReturnBadRequestObjectResult()
        {
            try
            {
                int EmployeeId = 48;
                var response = employeeController.DeleteEmployee(EmployeeId);
                Assert.IsType<BadRequestObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Given Employee Id Search Method is Used it Returns Ok Result
        /// </summary>
        [Fact]
        public void GivenEmployeeId_WhenCalledSearchEmployee_ShouldReturnOkResult()
        {
            try
            {
                int EmployeeId = 49;
                var response = employeeController.SearchEmployee(EmployeeId);
                Assert.IsType<OkObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Given Wrong Employee Id Search Method is Used it Returns Bad Request Obejct Result
        /// </summary>
        [Fact]
        public void GivenWrongEmployeeId_WhenCalledSearchEmployee_ShouldReturnBadRequestObjectResult()
        {
            try
            {
                int EmployeeId = 69;
                var response = employeeController.SearchEmployee(EmployeeId);
                Assert.IsType<BadRequestObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }
    }
}