using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeCommonLayer;

namespace EmployeeBuisenessLayer.Interface
{
    public interface IUserBuiseness
    {
        Task<bool> UserRegistration(UserModel userModel);
    }
}
