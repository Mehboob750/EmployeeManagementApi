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

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                var response = await this.employeeBusiness.AddEmployee(employeeModel);
                if (!response.Equals(false))
                {
                    bool success = true;
                    var message = "Data Added Successfully";
                    return this.Ok(new { success, message, data = employeeModel });
                }
                else
                {
                    bool success = false;
                    var message = "Fail To Add Data";
                    return this.BadRequest(new { success, message, data = "null" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false , message = e.Message, data = "null" });
            }
        }

        [HttpGet]
        public IActionResult ReadEmployee()
        {
            try
            {
                var response = this.employeeBusiness.ReadEmployee();
                if (!response.Equals(false))
                {
                    bool status = true;
                    var message = "Data Read Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Fail To Read Data";
                    return this.BadRequest(new { status, message, data = "null" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, data = "null" });
            }
        }

        [HttpPut("{EmployeeId}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] EmployeeModel employeeModel)
        {
            try
            {
                var response = await this.employeeBusiness.UpdateEmployee(employeeModel);
                if (!response.Equals(false))
                {
                    bool status = true;
                    var message = "Data Updated Successfully";
                    return this.Ok(new { status, message, data = employeeModel });
                }
                else
                {
                    bool status = false;
                    var message = "Fail To Update Data";
                    return this.BadRequest(new { status, message, data = "null" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, data = "null" });
            }
        }

        [HttpDelete("{EmployeeId}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] EmployeeModel employeeModel)
        {
            try
            {
                var response = await this.employeeBusiness.DeleteEmployee(employeeModel);
                if (!response.Equals(false))
                {
                    bool status = true;
                    var message = "Deleted Successfully";
                    return this.Ok(new { status, message, data = employeeModel });
                }
                else
                {
                    bool status = false;
                    var message = "No record To Delete";
                    return this.BadRequest(new { status, message, data = "null" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, data = "null" });
            }
        }

        [HttpGet("{EmployeeId}")]
        public IActionResult SearchEmployee([FromRoute] EmployeeModel employeeModel)
        {
            try
            {
                var response = this.employeeBusiness.SearchEmployee(employeeModel);
                if (!response.Count.Equals(0))
                {
                    bool status = true;
                    var message = "Record Found";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Record Not Found";
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
