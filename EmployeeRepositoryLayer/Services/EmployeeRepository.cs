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
    public class EmployeeRepository : IEmployeeRepository
    {
        private static readonly string connectionVariable = "Server=DESKTOP-EUJ5D3D;Database=EmployeeDatabase;Trusted_Connection=true;MultipleActiveResultSets=True";

        SqlConnection sqlConnection = new SqlConnection(connectionVariable);

        public async Task<bool> AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spInsertRecord", this.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FirstName", employeeModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", employeeModel.LastName);
                sqlCommand.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                sqlCommand.Parameters.AddWithValue("@EmailId", employeeModel.EmailId);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", employeeModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@City", employeeModel.City);
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
