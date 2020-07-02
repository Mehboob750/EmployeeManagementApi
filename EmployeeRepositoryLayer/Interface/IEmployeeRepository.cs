//-----------------------------------------------------------------------
// <copyright file="IEmployeeRepository.cs" company="BridgeLabz Solution">
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

    /// <summary>
    /// Interface of Employee Repository Layer
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// It is an interface of Add Employee Method
        /// </summary>
        /// <param name="employeeModel">It is an object of Employee Model class</param>
        /// <returns>If record added it returns true</returns>
        Task<bool> AddEmployee(EmployeeModel employeeModel);

        /// <summary>
        /// It is an interface of Read Employee Method 
        /// </summary>
        /// <returns>It returns the all records in IList</returns>
        IList<EmployeeModel> ReadEmployee();

        /// <summary>
        /// It is an interface of Update Employee Method
        /// </summary>
        /// <param name="employeeModel">It is an object of Employee Model class</param>
        /// <returns>If record is Updated it returns true</returns>
        Task<bool> UpdateEmployee(EmployeeModel employeeModel);

        /// <summary>
        /// It is an interface of Delete Employee Method
        /// </summary>
        /// <param name="employeeModel">It is an object of Employee Model class</param>
        /// <returns>If record is Deleted it returns true</returns>
        Task<bool> DeleteEmployee(EmployeeModel employeeModel);

        /// <summary>
        /// It is an interface of Search Employee Method
        /// </summary>
        /// <param name="employeeModel">It is an object of Employee Model class</param>
        /// <returns>It returns the search record</returns>
        IList<EmployeeModel> SearchEmployee(EmployeeModel employeeModel);
    }
}
