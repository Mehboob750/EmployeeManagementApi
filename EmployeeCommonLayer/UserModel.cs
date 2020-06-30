using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeCommonLayer
{
    public class UserModel
    {
        [Required]
        public int EmployeeId { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 3,
         ErrorMessage = "The property {0} should have {1} maximum characters and {2} minimum characters")]
        public string FirstName { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 3,
         ErrorMessage = "The property {0} should have {1} maximum characters and {2} minimum characters")]
        public string LastName { get; set; }

        public string Gender { get; set; }

        [RegularExpression("^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$", ErrorMessage = "EmailId is not valid")]
        public string EmailId { get; set; }

        [RegularExpression("([1-9]{1}[0-9]{9})$", ErrorMessage = "Phone number is not valid")]

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime UpdationDate { get; set; }

        [RegularExpression("^.{8,30}$", ErrorMessage = "Password Length should be between 8 to 15")]
        public string Password { get; set; }



    }
}
