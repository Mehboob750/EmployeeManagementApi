﻿//-----------------------------------------------------------------------
// <copyright file="UserBL.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace EmployeeBuisenessLayer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EmployeeBuisenessLayer.Interface;
    using EmployeeCommonLayer;
    using EmployeeCommonLayer.Model;
    using EmployeeCommonLayer.RequestModel;
    using EmployeeCommonLayer.ResponseModel;
    using EmployeeRepositoryLayer.Interface;

    /// <summary>
    /// This Class is used to implement the methods of interface
    /// </summary>
    public class UserBL : IUserBL
    {
        /// <summary>
        /// Created the Reference of IUserRepository
        /// </summary>
        private readonly IUserRL userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserBL"/> class.
        /// </summary>
        /// <param name="userRepository">It contains the object IUserRepository</param>
        public UserBL(IUserRL userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// This Method is used to User Registration
        /// </summary>
        /// <param name="userModel">It contains the Object of User Model</param>
        /// <returns>If User Registered Successfully it returns true</returns>
        public IList<RegistrationResponseModel> UserRegistration(RegistrationRequestModel registrationModel)
        {
            try
            {
                if (registrationModel.FirstName == "" || registrationModel.LastName == "" || registrationModel.City == "" || registrationModel.EmailId == "" || registrationModel.PhoneNumber == "" || registrationModel.Gender == "" || registrationModel.Password == "")
                {
                    throw new EmployeeManagementException(EmployeeManagementException.ExceptionType.EMPTY_FIELD_EXCEPTION, "Empty Variable Field");
                }
                else if (registrationModel.FirstName == null || registrationModel.LastName == null || registrationModel.City == null || registrationModel.EmailId == null || registrationModel.PhoneNumber == null || registrationModel.Gender == null || registrationModel.Password == null)
                {  
                    throw new EmployeeManagementException(EmployeeManagementException.ExceptionType.NULL_FIELD_EXCEPTION, "Null Variable Field");
                }

                var response = this.userRepository.UserRegistration(registrationModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// This Method is used to User Login
        /// </summary>
        /// <param name="userModel">It contains the Object of User Model</param>
        /// <returns>If User Login Successfully it returns true</returns>
        public LoginResponseModel UserLogin(LoginRequestModel userLoginModel)
        {
            try
            {
                // Call the User Login Method of User Repository Class
                var response = this.userRepository.UserLogin(userLoginModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);

            }
        }

        /// <summary>
        /// This Method is used when Forget Password
        /// </summary>
        /// <param name="forgotPassword">It is an object of Forgot Password Model</param>
        /// <returns>It returns the EmailId </returns>
        public object ForgetPassword(ForgotPasswordModel forgotPassword)
        {
            try
            {
                var response = this.userRepository.ForgetPassword(forgotPassword);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public object ResetPassword(ResetPasswordModel resetModel)
        {
            try
            {
                var response = this.userRepository.ResetPassword(resetModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        
        }
    }
}
