//-----------------------------------------------------------------------
// <copyright file="UserTestCases.cs" company="BridgeLabz Solution">
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
    using EmployeeCommonLayer.RequestModel;
    using EmployeeCommonLayer.ResponseModel;
    using EmployeeManagementApi.Controllers;
    using EmployeeRepositoryLayer.Interface;
    using EmployeeRepositoryLayer.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;

    /// <summary>
    /// This class contains the testcases of User
    /// </summary>
    public class UserTestCases
    {
        /// <summary>
        /// Created Reference of UserController
        /// </summary>
        UserController userController;

        /// <summary>
        /// Created Reference of IUserBL
        /// </summary>
        IUserBL userBuiseness;

        /// <summary>
        /// Created Reference of IUserRL
        /// </summary>
        IUserRL userRepository;

        /// <summary>
        /// Created Reference of IConfiguration
        /// </summary>
        IConfiguration configuration;

        /// <summary>
        /// Default constructor used to create new objects
        /// </summary>
        public UserTestCases()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            this.configuration = configurationBuilder.Build();
            userRepository = new UserRL();
            userBuiseness = new UserBL(userRepository);
            userController = new UserController(userBuiseness, configuration);
        }

        /// <summary>
        /// Given Registration Request Model check for not Null
        /// </summary>
        [Fact]
        public void GivenRegisterationRequestModel_WhenCheckForNotNull_ShouldReturn()
        {
            RegistrationRequestModel registrationModel = new RegistrationRequestModel();
            registrationModel.FirstName = "Javid";
            registrationModel.LastName = "Shaikh";
            registrationModel.Gender = "male";
            registrationModel.EmailId = "javid36@gmail.com";
            registrationModel.PhoneNumber = "7878654502";
            registrationModel.City = "Mumbai";
            registrationModel.Password = "javid@123";

            Assert.NotNull(registrationModel);
        }

        /// <summary>
        /// Given RegistrationRequestModel Registered Returns Ok Result 
        /// </summary>
        [Fact]
        public void GivenRegisterationRequestModel_WhenRegisterCall_ShouldReturnOkResult()
        {
            try
            {
                RegistrationRequestModel registrationModel = new RegistrationRequestModel();
                registrationModel.FirstName = "Javid";
                registrationModel.LastName = "Shaikh";
                registrationModel.Gender = "male";
                registrationModel.EmailId = "javid36@gmail.com";
                registrationModel.PhoneNumber = "7878654502";
                registrationModel.City = "Mumbai";
                registrationModel.Password = "javid@123";

                var response = userController.UserRegistration(registrationModel);
                Assert.IsType<OkObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        [Fact]
        public void GivenRegisterationRequestModel_WhenRegistered_ShouldReturnsResult()
        {
            try
            {
                RegistrationRequestModel  registrationModel = new RegistrationRequestModel();
                registrationModel.FirstName = "John";
                registrationModel.LastName = "Sinha";
                registrationModel.Gender = "male";
                registrationModel.EmailId = "john@gmail.com";
                registrationModel.PhoneNumber = "7888544502";
                registrationModel.City = "Delhi";
                registrationModel.Password = "john@1234";

                var response = userController.UserRegistration(registrationModel) as OkObjectResult;
                var serializeResponse = JToken.Parse(JsonConvert.SerializeObject(response.Value));
                var responseSuccess = serializeResponse["status"].ToObject<bool>();
                var responseMessage = serializeResponse["message"].ToString();

                bool success = true;
                string message = "User Registered Successfully";

                Assert.IsType<OkObjectResult>(response);
                Assert.Equal(success, responseSuccess);
                Assert.Equal(message, responseMessage);
            }
            catch (Exception exception)
            {
                Assert.IsType<BadRequestObjectResult>(exception);
            }
        }

        /// <summary>
        /// Given RegistrationRequestModel With Empty Fields Registered Returns Bad Object Result 
        /// </summary>
        [Fact]
        public void GivenRegisterationRequestModel_WhenFieldsAreEmpty_ShouldReturnBadRequestObjectResult()
        {
            try
            {
                RegistrationRequestModel registrationModel = new RegistrationRequestModel();
                registrationModel.FirstName = "";
                registrationModel.LastName = "";
                registrationModel.Gender = "";
                registrationModel.EmailId = "javid12@gmail.com";
                registrationModel.PhoneNumber = "7876944502";
                registrationModel.City = "Mumbai";
                registrationModel.Password = "javid@123";

                var response = userController.UserRegistration(registrationModel);
                Assert.IsType<BadRequestObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Given RegistrationRequestModel With null Fields Registered Returns Bad Object Result 
        /// </summary>
        [Fact]
        public void GivenRegisterationRequestModel_WhenFieldsAreNull_ShouldReturnBadRequestObjectResult()
        {
            try
            {
                RegistrationRequestModel registrationModel = new RegistrationRequestModel();
                registrationModel.FirstName = "Javid";
                registrationModel.LastName = "Shaikh";
                registrationModel.Gender = "male";
                registrationModel.EmailId = null;
                registrationModel.PhoneNumber = "7876870450";
                registrationModel.City = "Mumbai";
                registrationModel.Password = "javid@123";

                var response = userController.UserRegistration(registrationModel);
                Assert.IsType<BadRequestObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Given LoginRequestModel When Login Returns Ok Result 
        /// </summary>
        [Fact]
        public void GivenLoginRequestModel_WhenUserLoginCalled_ShouldReturnOkResult()
        {
            try
            {
                LoginRequestModel loginRequest = new LoginRequestModel();
                loginRequest.EmailId = "vishal@gmail.com";
                loginRequest.Password = "vishal@123";

                var response = userController.UserLogin(loginRequest);
                Assert.IsType<OkObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Given wrong EmailId When Login Returns Bad Object Result 
        /// </summary>
        [Fact]
        public void GivenWrongEmailId_WhenUserLoginCalled_ShouldReturnBadRequestObjectResult()
        {
            try
            {
                LoginRequestModel loginRequest = new LoginRequestModel();
                loginRequest.EmailId = "vishal12@gmail.com";
                loginRequest.Password = "vishal@123";

                var response = userController.UserLogin(loginRequest);
                Assert.IsType<BadRequestObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Given wrong Password When Login Returns Bad Object Result 
        /// </summary>
        [Fact]
        public void GivenWrongPassword_WhenUserLoginCalled_ShouldReturnBadRequestObjectResult()
        {
            try
            {
                LoginRequestModel loginRequest = new LoginRequestModel();
                loginRequest.EmailId = "vishal@gmail.com";
                loginRequest.Password = "vishal@1";

                var response = userController.UserLogin(loginRequest);
                Assert.IsType<BadRequestObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Given null Password When Login Returns Bad Object Result 
        /// </summary>
        [Fact]
        public void GivenNullPassword_WhenUserLoginCalled_ShouldReturnBadRequestObjectResult()
        {
            try
            {
                LoginRequestModel loginRequest = new LoginRequestModel();
                loginRequest.EmailId = "vishal@gmail.com";
                loginRequest.Password = null;

                var response = userController.UserLogin(loginRequest);
                Assert.IsType<BadRequestObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Given Empty Password When Login Returns Bad Object Result 
        /// </summary>
        [Fact]
        public void GivenEmptyPassword_WhenUserLoginCalled_ShouldReturnBadRequestObjectResult()
        {
            try
            {
                LoginRequestModel loginRequest = new LoginRequestModel();
                loginRequest.EmailId = "vishal@gmail.com";
                loginRequest.Password = " ";

                var response = userController.UserLogin(loginRequest);
                Assert.IsType<BadRequestObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Given Empty EmailId When Login Returns Bad Object Result 
        /// </summary>
        [Fact]
        public void GivenEmptyEmailId_WhenUserLoginCalled_ShouldReturnBadRequestObjectResult()
        {
            try
            {
                LoginRequestModel loginRequest = new LoginRequestModel();
                loginRequest.EmailId = "";
                loginRequest.Password = "vishal@123";

                var response = userController.UserLogin(loginRequest);
                Assert.IsType<BadRequestObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }

        /// <summary>
        /// Given Null EmailId When Login Returns Bad Object Result 
        /// </summary>
        [Fact]
        public void GivenNullEmailId_WhenUserLoginCalled_ShouldReturnBadRequestObjectResult()
        {
            try
            {
                LoginRequestModel loginRequest = new LoginRequestModel();
                loginRequest.EmailId = null;
                loginRequest.Password = "vishal@123";

                var response = userController.UserLogin(loginRequest);
                Assert.IsType<BadRequestObjectResult>(response);
            }
            catch (Exception exception)
            {
                Assert.IsType<Exception>(exception);
            }
        }
    }
}
