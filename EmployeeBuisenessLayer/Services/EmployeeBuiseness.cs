//-----------------------------------------------------------------------
// <copyright file="EmployeeBuiseness.cs" company="BridgeLabz Solution">
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
    using EmployeeRepositoryLayer.Interface;

    /// <summary>
    /// This Class is used to implement the methods of interface
    /// </summary>
    public class EmployeeBuiseness : IEmployeeBuiseness
    {
        /// <summary>
        /// Created the Reference of IEmployeeRepository
        /// </summary>
        private readonly IEmployeeRepository employeeRepository;

        /// <summary>
        /// Initializes a new instance of the IEmployeeRepository
        /// </summary>
        /// <param name="employeeRepository">It contains the object IEmployeeRepository</param>
        public EmployeeBuiseness(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        /// <summary>
        /// This Method is used to add new Record
        /// </summary>
        /// <param name="employeeModel">It contains the Object of Employee Model</param>
        /// <returns>If record added it return true</returns>
        public async Task<bool> AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                if (employeeModel != null)
                {
                    // Call the Add Employee Method of Employee Repository Class
                    var response = await this.employeeRepository.AddEmployee(employeeModel);

                    if (response == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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
        public IList<EmployeeModel> ReadEmployee()
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
        public async Task<bool> UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                if (employeeModel != null)
                {
                    // Call the Update Employee Method of Employee Repository Class
                    var response = await this.employeeRepository.UpdateEmployee(employeeModel);
                    if (response == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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
        public async Task<bool> DeleteEmployee(EmployeeModel employeeModel)
        {
            try
            {
                if (employeeModel != null)
                {
                    // Call the Delete Employee Method of Employee Repository Class
                    var response = await this.employeeRepository.DeleteEmployee(employeeModel);
                    if (response == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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
        public IList<EmployeeModel> SearchEmployee(EmployeeModel employeeModel)
        {
            try
            {
                // Call the Search Employee Method of Employee Repository Class
                var response = this.employeeRepository.SearchEmployee(employeeModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
