//-----------------------------------------------------------------------
// <copyright file="EmployeeController.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace EmployeeManagement.Controllers
{
    using System;
    using System.Threading.Tasks;
    using EmployeeBuisenessLayer.Interface;
    using EmployeeCommonLayer;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Employee controller class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// It is an Reference of IEmployee Business
        /// </summary>
        private readonly IEmployeeBuiseness employeeBusiness;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// /// <param name="employeeBusiness">It is an object of IEmployee Business</param>
        public EmployeeController(IEmployeeBuiseness employeeBusiness)
        {
            this.employeeBusiness = employeeBusiness;
        }

        /// <summary>
        /// This Method is used to Add the new record
        /// </summary>
        /// <param name="employeeModel">It is an object of Employee Model class</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                // Call the Add Employee Method of Employee Business classs
                var response = await this.employeeBusiness.AddEmployee(employeeModel);

                // check if response is equal to true
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
                return this.BadRequest(new { success = false, message = e.Message, data = "null" });
            }
        }

        /// <summary>
        /// This Method is used to Read all the records
        /// </summary>
        /// <returns>Returns the result in SMD format</returns>
        [HttpGet]
        public IActionResult ReadEmployee()
        {
            try
            {
                // Call the Read Employee Method of Employee Business classs
                var response = this.employeeBusiness.ReadEmployee();

                // check if response is equal to true
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
                return this.BadRequest(new { success = false, message = e.Message, data = "null" });
            }
        }

        /// <summary>
        /// This Method is used to Update the record
        /// </summary>
        /// <param name="employeeModel">It is an object of Employee Model class</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpPut("{EmployeeId}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] EmployeeModel employeeModel)
        {
            try
            {
                // Call the Update Employee Method of Employee Business classs
                var response = await this.employeeBusiness.UpdateEmployee(employeeModel);

                // check if response is equal to true
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
                return this.BadRequest(new { success = false, message = e.Message, data = "null" });
            }
        }

        /// <summary>
        /// This method is used to delete an record
        /// </summary>
        /// <param name="employeeModel">It is an object of Employee Model class</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpDelete("{EmployeeId}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] EmployeeModel employeeModel)
        {
            try
            {
                // Call the Delete Employee Method of Employee Business classs
                var response = await this.employeeBusiness.DeleteEmployee(employeeModel);

                // check if response is equal to true
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
                return this.BadRequest(new { success = false, message = e.Message, data = "null" });
            }
        }

        /// <summary>
        /// This Method is used to search an specific employee
        /// </summary>
        /// <param name="employeeModel">It is an object of Employee Model class</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpGet("{EmployeeId}")]
        public IActionResult SearchEmployee([FromRoute] EmployeeModel employeeModel)
        {
            try
            {
                // Call the Search Employee Method of Employee Business classs
                var response = this.employeeBusiness.SearchEmployee(employeeModel);

                // check if response count is equal to 1
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
                return this.BadRequest(new { success = false, message = e.Message, data = "null" });
            }
        }
    }
}
