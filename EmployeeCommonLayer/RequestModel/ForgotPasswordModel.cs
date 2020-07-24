using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeCommonLayer.RequestModel
{
    public class ForgotPasswordModel
    {
        /// <summary>
        /// Gets or sets the EmailId
        /// </summary>
        [RegularExpression("^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$", ErrorMessage = "EmailId is not valid")]
        public string EmailId { get; set; }
    }
}
