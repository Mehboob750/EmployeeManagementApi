using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using EmployeeCommonLayer;
using EmployeeRepositoryLayer.Interface;
using Microsoft.Azure.Amqp.Framing;

namespace EmployeeRepositoryLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private static readonly string connectionVariable = "Server=DESKTOP-EUJ5D3D;Database=EmployeeDatabase;Trusted_Connection=true;MultipleActiveResultSets=True";

        SqlConnection sqlConnection = new SqlConnection(connectionVariable);

        EncryptDecrypt encryptDecrypt = new EncryptDecrypt();

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
                string password = encryptDecrypt.EncodePasswordToBase64(userModel.Password);
                sqlCommand.Parameters.AddWithValue("@Password", password);

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

        public async Task<bool> UserLogin(UserModel userModel)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spUserLogin", this.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmailId", userModel.EmailId);
                string password = encryptDecrypt.EncodePasswordToBase64(userModel.Password);
                sqlCommand.Parameters.AddWithValue("@Password", password);
                this.sqlConnection.Open();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                int Status = 0;
                while (sqlDataReader.Read())
                {
                    Status = sqlDataReader.GetInt32(0);
                }
                sqlConnection.Close();
                if (Status == 1)
                {
                    return true;
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
