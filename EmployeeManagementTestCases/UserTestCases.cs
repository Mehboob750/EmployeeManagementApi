using System;
using EmployeeBuisenessLayer.Interface;
using EmployeeBuisenessLayer.Services;
using EmployeeCommonLayer.RequestModel;
using EmployeeManagementApi.Controllers;
using EmployeeRepositoryLayer.Interface;
using EmployeeRepositoryLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace EmployeeManagementTestCases
{
    public class UserTestCases
    {
        UserController userController;
        IUserBL userBuiseness;
        IUserRL userRepository;
        IConfiguration configuration;
        public UserTestCases()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            this.configuration = configurationBuilder.Build();
            userRepository = new UserRL();
            userBuiseness = new UserBL(userRepository);
            userController = new UserController(userBuiseness, configuration);
        }

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
