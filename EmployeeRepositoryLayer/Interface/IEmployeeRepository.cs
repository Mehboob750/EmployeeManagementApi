using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeCommonLayer;

namespace EmployeeRepositoryLayer.Interface
{
    public interface IEmployeeRepository
    {
        Task<bool> AddEmployee(EmployeeModel employeeModel);

        IList<EmployeeModel> ReadEmployee();

    }
}
