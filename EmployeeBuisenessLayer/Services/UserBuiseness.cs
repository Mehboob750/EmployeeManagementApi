using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeBuisenessLayer.Interface;
using EmployeeCommonLayer;
using EmployeeRepositoryLayer.Interface;
using EmployeeRepositoryLayer.Services;

namespace EmployeeBuisenessLayer.Services
{
    public class UserBuiseness : IUserBuiseness
    {
        public readonly IUserRepository userRepository;

        public UserBuiseness(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> UserRegistration(UserModel userModel)
        {
            try
            {
                if (userModel != null)
                {
                    var response = await userRepository.UserRegistration(userModel);

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
