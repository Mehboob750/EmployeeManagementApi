//-----------------------------------------------------------------------
// <copyright file="ResetPasswordModel.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace EmployeeCommonLayer.RequestModel
{
    /// <summary>
    /// It is an Model Class For Reset Password Model
    /// </summary>
    public class ResetPasswordModel
    {
        /// <summary>
        /// Get and set reset token
        /// </summary>
        public string ResetToken { get; set; }

        /// <summary>
        /// Get and set new password
        /// </summary>
        public string NewPassword { get; set; }
    }
}