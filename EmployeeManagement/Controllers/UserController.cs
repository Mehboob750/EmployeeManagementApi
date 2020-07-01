using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBuisenessLayer.Interface;
using EmployeeCommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public readonly IUserBuiseness userBusiness;

        public UserController(IUserBuiseness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        [HttpPost]
        [Route("userRegistration")]
        public async Task<IActionResult> UserRegistration(UserModel userModel)
        {
            try
            {
                var response = await this.userBusiness.UserRegistration(userModel);
                if (!response.Equals(null))
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
                return BadRequest(new { success = false, message = e.Message, data = "null" });
            }
        }

        [HttpPost]
        [Route("userLogin")]
        public async Task<IActionResult> UserLogin(UserModel userModel)
        {
            try
            {
                var response = await this.userBusiness.UserLogin(userModel);
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
                return BadRequest(new { success = false, message = e.Message, data = "null" });
            }
        }
    }
}
