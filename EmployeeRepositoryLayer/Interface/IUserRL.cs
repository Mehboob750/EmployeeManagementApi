//-----------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace EmployeeRepositoryLayer.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EmployeeCommonLayer;
    using EmployeeCommonLayer.Model;
    using EmployeeCommonLayer.RequestModel;
    using EmployeeCommonLayer.ResponseModel;

    /// <summary>
    /// Interface of User Repository Layer
    /// </summary>
    public interface IUserRL
    {
        /// <summary>
        /// It is an interface of User Registration Method
        /// </summary>
        /// <param name="userModel">It is an object of User Model class</param>
        /// <returns>If register successfully it returns true</returns>
        IList<RegistrationResponseModel> UserRegistration(RegistrationRequestModel registrationModel);

        /// <summary>
        ///  It is an interface of User Login Method
        /// </summary>
        /// <param name="userModel">It is an object of User Model class</param>
        /// <returns>If Login Successfully it returns true</returns>
        LoginResponseModel UserLogin(LoginRequestModel userLoginModel);

        Task<string> ForgetPassword(ForgotPasswordModel forgotPassword);

        object ResetPassword(ResetPasswordModel resetModel);
    }
}
