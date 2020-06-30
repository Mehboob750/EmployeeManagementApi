using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeCommonLayer
{
    public class EncryptDecrypt
    {
        public string EncodePasswordToBase64(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
    }
}
