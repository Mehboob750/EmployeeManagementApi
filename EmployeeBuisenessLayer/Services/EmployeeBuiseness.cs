using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeBuisenessLayer.Interface;
using EmployeeCommonLayer;
using EmployeeRepositoryLayer.Interface;

namespace EmployeeBuisenessLayer.Services
{
    public class EmployeeBuiseness : IEmployeeBuiseness
    {
        public readonly IEmployeeRepository employeeRepository;

        public EmployeeBuiseness(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<bool> AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                if (employeeModel != null)
                {
                    var response = await employeeRepository.AddEmployee(employeeModel);

                    if (response == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public IList<EmployeeModel> ReadEmployee()
        {
            try
            {
                var response = employeeRepository.ReadEmployee();
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<bool> UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                if (employeeModel != null)
                {
                    var response = await employeeRepository.UpdateEmployee(employeeModel);
                    if (response == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<bool> DeleteEmployee(EmployeeModel employeeModel)
        {
            try
            {
                if (employeeModel != null)
                {
                    var response = await employeeRepository.DeleteEmployee(employeeModel);
                    if (response == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
