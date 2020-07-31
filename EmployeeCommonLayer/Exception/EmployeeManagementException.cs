//-----------------------------------------------------------------------
// <copyright file="EmployeeManagementException.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace EmployeeBuisenessLayer.Services
{
    using System;

    /// <summary>
    /// This class is used to define Custom Exceptions
    /// </summary>
    public class EmployeeManagementException : Exception
    {
        /// <summary>
        /// Parameterized constructor used to Initialize type of Exception
        /// </summary>
        /// <param name="type">It contains the type of Exception</param>
        /// <param name="message">It contains the message</param>
        public EmployeeManagementException(EmployeeManagementException.ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }

        /// <summary>
        /// Enum is Used to define Enumerated Data types
        /// </summary>
        public enum ExceptionType
        {
            /// <summary>
            /// It is used for Null Field
            /// </summary>
            NULL_FIELD_EXCEPTION,

            /// <summary>
            /// It is Used for Empty Field
            /// </summary>
            EMPTY_FIELD_EXCEPTION
        }

        /// <summary>
        /// It gets or sets Exception Type
        /// </summary>
        public ExceptionType type { get; set; }
    }
}
