using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeCommonLayer.RequestModel
{
    public class ResetPasswordModel
    {
        /// <summary>
        /// Get and set Email
        /// </summary>
       // public string EmailId { get; set; }

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
