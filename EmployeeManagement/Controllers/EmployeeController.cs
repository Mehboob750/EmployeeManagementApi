using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBuisenessLayer.Interface;
using EmployeeCommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeBuiseness employeeBusiness;

        public EmployeeController(IEmployeeBuiseness employeeBusiness)
        {
            this.employeeBusiness = employeeBusiness;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Post()
        {
            return new string[] { "Value 1", "Value 2" };
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                var response = await this.employeeBusiness.AddEmployee(employeeModel);
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

        [HttpGet]
        [Route("read")]
        public IActionResult ReadEmployee()
        {
            try
            {
                var response = this.employeeBusiness.ReadEmployee();
                if (!response.Equals(null))
                {
                    var status = "Success";
                    return this.Ok(new { status, response });
                }
                else
                {
                    var status = "Failed";
                    var message = "Fail To Read Data";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                var response = await this.employeeBusiness.UpdateEmployee(employeeModel);
                if (!response.Equals(null))
                {
                    var status = "Success";
                    var message = "Data Updated Successfully";
                    return this.Ok(new { status, message });
                }
                else
                {
                    var status = "Failed";
                    var message = "Fail To Update Data";
                    return this.BadRequest(new { status, message });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteEmployee(EmployeeModel employeeModel)
        {
            try
            {
                var response = await this.employeeBusiness.DeleteEmployee(employeeModel);
                if (!response.Equals(null))
                {
                    var status = "Success";
                    var message = "Deleted Successfully";
                    return this.Ok(new { status, message });
                }
                else
                {
                    var status = "Failed";
                    var message = "Fail To Delete Data";
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
