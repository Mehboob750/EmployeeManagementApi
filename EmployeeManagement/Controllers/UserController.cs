//-----------------------------------------------------------------------
// <copyright file="UserController.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace EmployeeManagementApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using EmployeeBuisenessLayer.Interface;
    using EmployeeCommonLayer;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// User Controller class contains the API for registration and login
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// It is an Reference of IUser Business
        /// </summary>
        private readonly IUserBuiseness userBusiness;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userBusiness">It is an object of IUser Business</param>
        public UserController(IUserBuiseness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        /// <summary>
        /// This Method is used for User Registration
        /// </summary>
        /// <param name="userModel">It is an object of User Model</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpPost]
        [Route("userRegistration")]
        public async Task<IActionResult> UserRegistration(UserModel userModel)
        {
            try
            {
                // Call the User Registration Method of User Business classs
                var response = await this.userBusiness.UserRegistration(userModel);

                // check if response is equal to true
                if (!response.Equals(false))
                {
                    bool status = true;
                    var message = "User Registered Successfully";
                    return this.Ok(new { status, message, data = userModel });
                }
                else
                {
                    bool status = false;
                    var message = "Fail To Register User";
                    return this.BadRequest(new { status, message, data = "null" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, data = "null" });
            }
        }

        /// <summary>
        /// This Method is used for User Login
        /// </summary>
        /// <param name="userModel">It is an object of User Model</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpPost]
        [Route("userLogin")]
        public async Task<IActionResult> UserLogin(UserModel userModel)
        {
            try
            {
                // Call the User Login Method of User Business classs
                var response = await this.userBusiness.UserLogin(userModel);

                // check if response is equal to true
                if (!response.Equals(false))
                {
                    bool status = true;
                    var message = "Login Successfully";
                    return this.Ok(new { status, message, data = userModel });
                }
                else
                {
                    bool status = false;
                    var message = "Fail To Login";
                    return this.BadRequest(new { status, message, data = "null" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, data = "null" });
            }
        }
    }
}
