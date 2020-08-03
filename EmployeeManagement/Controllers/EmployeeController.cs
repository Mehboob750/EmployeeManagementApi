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
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using EmployeeBuisenessLayer.Interface;
    using EmployeeBuisenessLayer.Services;
    using EmployeeCommonLayer;
    using EmployeeCommonLayer.RequestModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Distributed;
    using Newtonsoft.Json;

    /// <summary>
    /// Employee controller class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// It is an Reference of IEmployee Business
        /// </summary>
        private readonly IEmployeeBL employeeBusiness;

        private readonly IDistributedCache distributedCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// /// <param name="employeeBusiness">It is an object of IEmployee Business</param>
        public EmployeeController(IEmployeeBL employeeBusiness, IDistributedCache distributedCache)
        {
            this.employeeBusiness = employeeBusiness;
            this.distributedCache = distributedCache;
        }

        /// <summary>
        /// This Method is used to Add the new record
        /// </summary>
        /// <param name="employeeModel">It is an object of Employee Model class</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeRequestModel employeeModel)
        {
            try
            {
                if (employeeModel.FirstName == null || employeeModel.LastName == null || employeeModel.City == null || employeeModel.EmailId == null || employeeModel.PhoneNumber == null || employeeModel.Gender == null)
                {
                    throw new EmployeeManagementException(EmployeeManagementException.ExceptionType.NULL_FIELD_EXCEPTION, "Field should not be null");
                }
                else if (employeeModel.FirstName == "" || employeeModel.LastName == "" || employeeModel.City == "" || employeeModel.EmailId == "" || employeeModel.PhoneNumber == "" || employeeModel.Gender == "")
                {
                    throw new EmployeeManagementException(EmployeeManagementException.ExceptionType.EMPTY_FIELD_EXCEPTION, "Field should not be empty");
                }

                string cacheKey = "employeeDetails";

                // Call the Add Employee Method of Employee Business classs
                var response =  this.employeeBusiness.AddEmployee(employeeModel);
                
                // check if response is equal to true
                if (!response.EmployeeId.Equals(0))
                {
                    distributedCache.Remove(cacheKey);
                    bool status = true;
                    var message = "Data Added Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Data already Present";
                    return this.Conflict(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message});
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
                List<EmployeeResponseModel> response = null;

                string cacheKey = "employeeDetails";
                string serializedList;

                var encodedList = distributedCache.Get(cacheKey);

                if (encodedList != null)
                {
                    serializedList = Encoding.UTF8.GetString(encodedList);
                    response = JsonConvert.DeserializeObject<List<EmployeeResponseModel>>(serializedList);
                }
                else
                {
                    response = this.employeeBusiness.ReadEmployee();
                    serializedList = JsonConvert.SerializeObject(response);
                    encodedList = Encoding.UTF8.GetBytes(serializedList);
                    var options = new DistributedCacheEntryOptions()
                                      .SetSlidingExpiration(TimeSpan.FromMinutes(20))
                                      .SetAbsoluteExpiration(DateTime.Now.AddHours(6));
                    distributedCache.Set(cacheKey, encodedList, options);
                }

                // Call the Read Employee Method of Employee Business classs
               // var response = this.employeeBusiness.ReadEmployee();

                // check if response is equal to true
                if (!response.Equals(null))
                {
                    bool status = true;
                    var message = "Data Read Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Data Not Found";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        /// <summary>
        /// This Method is used to Update the record
        /// </summary>
        /// <param name="employeeModel">It is an object of Employee Model class</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpPut("{EmployeeId}")]
        public IActionResult UpdateEmployee([FromRoute] int EmployeeId, [FromBody] EmployeeRequestModel employeeModel)
        {
            try
            {
                string cacheKeyForEmployees = "employeeDetails";
                string cacheKeyForEmployee = EmployeeId.ToString();

                // Call the Update Employee Method of Employee Business classs
                var response = this.employeeBusiness.UpdateEmployee(EmployeeId, employeeModel);
                // check if response is equal to true
                if (!response.EmployeeId.Equals(0))
                {
                    distributedCache.Remove(cacheKeyForEmployees);
                    distributedCache.Remove(cacheKeyForEmployee);
                    bool status = true;
                    var message = "Data Updated Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "EmployeeId Not Found";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        /// <summary>
        /// This method is used to delete an record
        /// </summary>
        /// <param name="employeeModel">It is an object of Employee Model class</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpDelete("{EmployeeId}")]
        public IActionResult DeleteEmployee([FromRoute] int EmployeeId)
        {
            try
            {
                string cacheKeyForEmployees = "employeeDetails";
                string cacheKeyForEmployee = EmployeeId.ToString();

                // Call the Delete Employee Method of Employee Business classs
                var response =  this.employeeBusiness.DeleteEmployee(EmployeeId);

                // check if response is equal to true
                if (!response.EmployeeId.Equals(0))
                {
                    distributedCache.Remove(cacheKeyForEmployees);
                    distributedCache.Remove(cacheKeyForEmployee);
                    bool status = true;
                    var message = "Deleted Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "No record To Delete";
                    return this.NotFound(new { status, message});
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message});
            }
        }

        /// <summary>
        /// This Method is used to search an specific employee
        /// </summary>
        /// <param name="employeeModel">It is an object of Employee Model class</param>
        /// <returns>Returns the result in SMD format</returns>
        [HttpGet("{EmployeeId}")]
        public IActionResult SearchEmployee([FromRoute] int EmployeeId)
        {
            try
            {
                EmployeeResponseModel response = new EmployeeResponseModel();

                string cacheKey = EmployeeId.ToString(); 
                string serializedEmployeeData;

                var encodedData = distributedCache.Get(cacheKey);

                if (encodedData != null)
                {
                    serializedEmployeeData = Encoding.UTF8.GetString(encodedData);
                    response = JsonConvert.DeserializeObject<EmployeeResponseModel>(serializedEmployeeData);
                }
                else
                {
                    response = this.employeeBusiness.SearchEmployee(EmployeeId);
                    serializedEmployeeData = JsonConvert.SerializeObject(response);
                    encodedData = Encoding.UTF8.GetBytes(serializedEmployeeData);
                    var options = new DistributedCacheEntryOptions()
                                      .SetSlidingExpiration(TimeSpan.FromMinutes(20))
                                      .SetAbsoluteExpiration(DateTime.Now.AddHours(6));
                    distributedCache.Set(cacheKey, encodedData, options);
                }

                // Call the Search Employee Method of Employee Business classs
                //var response = this.employeeBusiness.SearchEmployee(EmployeeId);

                // check if response count is equal to 1
                if (!response.EmployeeId.Equals(0))
                {
                    bool status = true;
                    var message = "Record Found";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Record Not Found";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message});
            }
        }
    }
}
