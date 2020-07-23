//-----------------------------------------------------------------------
// <copyright file="EmployeeModel.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace EmployeeCommonLayer
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// This class contains all the parameter used in Employee Table
    /// </summary>
    public class EmployeeResponseModel
    {
        /// <summary>
        /// Gets or sets the Employee Id
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the First name Of Employee
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Last name of Employee
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Gender of Employee
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the EmailId of Employee
        /// </summary>
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets the Phone Number of Employee
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the City Of Employee
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the Registration Date of Employee
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Gets or sets the Updated Date of Employee
        /// </summary>
        public DateTime UpdationDate { get; set; }
    }
}
