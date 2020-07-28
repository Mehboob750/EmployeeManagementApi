using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBuisenessLayer.Services
{
    public class EmployeeManagementException : Exception
    {
        public enum ExceptionType
        {
            NULL_FIELD_EXCEPTION,
            EMPTY_FIELD_EXCEPTION
        }

        public ExceptionType type;

        public EmployeeManagementException(EmployeeManagementException.ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
