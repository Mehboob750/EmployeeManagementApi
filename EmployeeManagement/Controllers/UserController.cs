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

        [HttpGet]
        public ActionResult<IEnumerable<string>> Post()
        {
            return new string[] { "Value 1", "Value 2" };
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
                    var status = "Success";
                    var message = "Data Added Successfully";
                    return this.Ok(new { status, message });
                }
                else
                {
                    var status = "Failed";
                    var message = "Fail To Add Data";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
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
                    var status = "Success";
                    var message = "Login Successfully";
                    return this.Ok(new { status, message });
                }
                else
                {
                    var status = "Failed";
                    var message = "Fail To Login";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }
    }
}
