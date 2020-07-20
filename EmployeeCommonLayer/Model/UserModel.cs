//-----------------------------------------------------------------------
// <copyright file="UserModel.cs" company="BridgeLabz Solution">
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

    /// <summary>
    ///  This class contains all the parameter used in User Table
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Gets or sets the Employee Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the First name
        /// </summary>
        [StringLength(maximumLength: 20, MinimumLength = 3,
         ErrorMessage = "The property {0} should have {1} maximum characters and {2} minimum characters")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Last name
        /// </summary>
        [StringLength(maximumLength: 20, MinimumLength = 3,
         ErrorMessage = "The property {0} should have {1} maximum characters and {2} minimum characters")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the EmailId
        /// </summary>
        [RegularExpression("^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$", ErrorMessage = "EmailId is not valid")]
        public string EmailId { get; set; }

        [RegularExpression("([1-9]{1}[0-9]{9})$", ErrorMessage = "Phone number is not valid")]

        /// <summary>
        /// Gets or sets the Phone Number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the Registration Date
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Gets or sets the Updated Date
        /// </summary>
        public DateTime UpdationDate { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [RegularExpression("^.{8,30}$", ErrorMessage = "Password Length should be between 8 to 15")]
        public string Password { get; set; }
    }
}
