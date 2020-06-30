using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeCommonLayer;

namespace EmployeeBuisenessLayer.Interface
{
    public interface IEmployeeBuiseness
    {
        Task<bool> AddEmployee(EmployeeModel employeeModel);

        IList<EmployeeModel> ReadEmployee();

        Task<bool> UpdateEmployee(EmployeeModel employeeModel);
    }
}
