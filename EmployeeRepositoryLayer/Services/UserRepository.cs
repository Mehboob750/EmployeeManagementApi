using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using EmployeeCommonLayer;
using EmployeeRepositoryLayer.Interface;

namespace EmployeeRepositoryLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private static readonly string connectionVariable = "Server=DESKTOP-EUJ5D3D;Database=EmployeeDatabase;Trusted_Connection=true;MultipleActiveResultSets=True";

        SqlConnection sqlConnection = new SqlConnection(connectionVariable);

        public async Task<bool> UserRegistration(UserModel userModel)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spUserRegister", this.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FirstName", userModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", userModel.LastName);
                sqlCommand.Parameters.AddWithValue("@Gender", userModel.Gender);
                sqlCommand.Parameters.AddWithValue("@EmailId", userModel.EmailId);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", userModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@City", userModel.City);
                sqlCommand.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);

                this.sqlConnection.Open();
                var response = await sqlCommand.ExecuteNonQueryAsync();

                if (response > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
