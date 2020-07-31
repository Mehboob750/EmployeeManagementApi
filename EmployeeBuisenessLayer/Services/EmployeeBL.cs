//-----------------------------------------------------------------------
// <copyright file="EmployeeBL.cs" company="BridgeLabz Solution">
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
    using EmployeeCommonLayer.RequestModel;
    using EmployeeRepositoryLayer.Interface;

    /// <summary>
    /// This Class is used to implement the methods of interface
    /// </summary>
    public class EmployeeBL : IEmployeeBL
    {
        /// <summary>
        /// Created the Reference of IEmployeeRepository
        /// </summary>
        private readonly IEmployeeRL employeeRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeBL"/> class.
        /// </summary>
        /// <param name="employeeRepository">It contains the object IEmployeeRepository</param>
        public EmployeeBL(IEmployeeRL employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        /// <summary>
        /// This Method is used to add new Record
        /// </summary>
        /// <param name="employeeModel">It contains the Object of Employee Model</param>
        /// <returns>If record added it return true</returns>
        public EmployeeResponseModel AddEmployee(EmployeeRequestModel employeeModel)
        {
            try
            {
                if (employeeModel.FirstName == "" || employeeModel.LastName == "" || employeeModel.City == "" || employeeModel.EmailId == "" || employeeModel.PhoneNumber == "" || employeeModel.Gender == "")
                {
                    throw new EmployeeManagementException(EmployeeManagementException.ExceptionType.EMPTY_FIELD_EXCEPTION, "Field should not be empty");
                }
                else if (employeeModel.FirstName == null || employeeModel.LastName == null || employeeModel.City == null || employeeModel.EmailId == null || employeeModel.PhoneNumber == null || employeeModel.Gender == null)
                {
                    throw new EmployeeManagementException(EmployeeManagementException.ExceptionType.NULL_FIELD_EXCEPTION, "Field should not be null");
                }

                // Call the Add Employee Method of Employee Repository Class
                var response = this.employeeRepository.AddEmployee(employeeModel);
                return response;

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// This Method is used to Read all Record
        /// </summary>
        /// <returns>It returns the all record</returns>
        public List<EmployeeResponseModel> ReadEmployee()
        {
            try
            {
                // Call the Read Employee Method of Employee Repository Class
                var response = this.employeeRepository.ReadEmployee();
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// This Method is used to Update a Record
        /// </summary>
        /// <param name="employeeModel">It contains the Object of Employee Model</param>
        /// <returns>If record updated it return true</returns>
        public EmployeeResponseModel UpdateEmployee(int EmployeeId, EmployeeRequestModel employeeModel)
        {
            try
            {
                // Call the Delete Employee Method of Employee Repository Class
                var response = this.employeeRepository.UpdateEmployee(EmployeeId, employeeModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// This Method is used to Delete the Record
        /// </summary>
        /// <param name="employeeModel">It contains the Object of Employee Model</param>
        /// <returns>If record deleted it return true</returns>
        public EmployeeResponseModel DeleteEmployee(int EmployeeId)
        {
            try
            {
                // Call the Delete Employee Method of Employee Repository Class
                var response = this.employeeRepository.DeleteEmployee(EmployeeId);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        ///  This Method is used to Search the Record
        /// </summary>
        /// <param name="employeeModel">It contains the Object of Employee Model</param>
        /// <returns>It returns the searched record</returns>
        public EmployeeResponseModel SearchEmployee(int EmployeeId)
        {
            try
            {
                // Call the Search Employee Method of Employee Repository Class
                var response = this.employeeRepository.SearchEmployee(EmployeeId);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
