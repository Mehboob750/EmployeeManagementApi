//-----------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace EmployeeRepositoryLayer.Services
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using EmployeeCommonLayer;
    using EmployeeRepositoryLayer.Interface;

    /// <summary>
    /// This Class is used to implement the methods of interface
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// It is an connection variable
        /// </summary>
        private static string connectionVariable = "Server=DESKTOP-EUJ5D3D;Database=EmployeeDatabase;Trusted_Connection=true;MultipleActiveResultSets=True";

        /// <summary>
        /// It is an SQL connection object
        /// </summary>
        private SqlConnection sqlConnection = new SqlConnection(connectionVariable);

        /// <summary>
        /// It creates the object of EncryptDecrypt class
        /// </summary>
        private EncryptDecrypt encryptDecrypt = new EncryptDecrypt();

        /// <summary>
        /// This Method is used to User Registration
        /// </summary>
        /// <param name="userModel">It contains the Object of User Model</param>
        /// <returns>If User Registered Successfully it returns true</returns>
        public async Task<bool> UserRegistration(UserModel userModel)
        {
            try
            {
                // create the object of SqlCommand and send the command and connection object
                SqlCommand sqlCommand = new SqlCommand("spUserRegister", this.sqlConnection);

                // It defines the command type
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Add the First Name Value to database
                sqlCommand.Parameters.AddWithValue("@FirstName", userModel.FirstName);

                // Add the Last Name Value to database
                sqlCommand.Parameters.AddWithValue("@LastName", userModel.LastName);

                // Add the Gender Value to database
                sqlCommand.Parameters.AddWithValue("@Gender", userModel.Gender);

                // Add the Email Id Value to database
                sqlCommand.Parameters.AddWithValue("@EmailId", userModel.EmailId);

                // Add the Phone Number Value to database
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", userModel.PhoneNumber);

                // Add the City Value to database
                sqlCommand.Parameters.AddWithValue("@City", userModel.City);

                // Add the Registration Date to database
                sqlCommand.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);

                // this varibale strores the Encrypted password
                string password = this.encryptDecrypt.EncodePasswordToBase64(userModel.Password);

                // Add the Encrypted password to database
                sqlCommand.Parameters.AddWithValue("@Password", password);

                // Opens the Sql Connection
                this.sqlConnection.Open();
                var response = await sqlCommand.ExecuteNonQueryAsync();

                // Check Response
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

        /// <summary>
        /// This Method is used to User Login
        /// </summary>
        /// <param name="userModel">It contains the Object of User Model</param>
        /// <returns>If User Login Successfully it returns true</returns>
        public async Task<bool> UserLogin(UserModel userModel)
        {
            try
            {
                // create the object of SqlCommand and send the command and connection object
                SqlCommand sqlCommand = new SqlCommand("spUserLogin", this.sqlConnection);

                // It defines the command type
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Add the Email Id
                sqlCommand.Parameters.AddWithValue("@EmailId", userModel.EmailId);
                string password = this.encryptDecrypt.EncodePasswordToBase64(userModel.Password);

                // Add the Encrypted password
                sqlCommand.Parameters.AddWithValue("@Password", password);

                // Opens the Sql Connection
                this.sqlConnection.Open();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                int status = 0;
                while (sqlDataReader.Read())
                {
                    status = sqlDataReader.GetInt32(0);
                }

                this.sqlConnection.Close();
                if (status == 1)
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
