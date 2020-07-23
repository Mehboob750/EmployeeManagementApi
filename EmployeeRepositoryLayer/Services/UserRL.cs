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
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Threading.Tasks;
    using EmployeeCommonLayer;
    using EmployeeCommonLayer.Model;
    using EmployeeCommonLayer.RequestModel;
    using EmployeeCommonLayer.ResponseModel;
    using EmployeeRepositoryLayer.Interface;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// This Class is used to implement the methods of interface
    /// </summary>
    public class UserRL : IUserRL
    {
        /// <summary>
        /// It is an connection variable
        /// </summary>
        //private static string connectionVariable = "Server=DESKTOP-EUJ5D3D;Database=EmployeeDatabase;Trusted_Connection=true;MultipleActiveResultSets=True";

        /// <summary>
        /// It is an SQL connection object
        /// </summary>
        // private SqlConnection sqlConnection = new SqlConnection(connectionVariable);

        SqlConnection sqlConnection;
        public UserRL()
        {
            var configuration = this.GetConfiguration();
            this.sqlConnection = new SqlConnection(configuration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        /// <summary>
        /// It creates the object of EncryptDecrypt class
        /// </summary>
        private EncryptDecrypt encryptDecrypt = new EncryptDecrypt();

        /// <summary>
        /// This Method is used to User Registration
        /// </summary>
        /// <param name="userModel">It contains the Object of User Model</param>
        /// <returns>If User Registered Successfully it returns true</returns>
        public IList<RegistrationResponseModel> UserRegistration(RegistrationRequestModel registrationModel)
        {
            try
            {
                RegistrationResponseModel responseModel = new RegistrationResponseModel();
                IList<RegistrationResponseModel> userModelList = new List<RegistrationResponseModel>();
                // create the object of SqlCommand and send the command and connection object
                SqlCommand sqlCommand = this.StoreProcedureConnection("spUserRegister", this.sqlConnection);

                // Add the First Name Value to database
                sqlCommand.Parameters.AddWithValue("@FirstName", registrationModel.FirstName);

                // Add the Last Name Value to database
                sqlCommand.Parameters.AddWithValue("@LastName", registrationModel.LastName);

                // Add the Gender Value to database
                sqlCommand.Parameters.AddWithValue("@Gender", registrationModel.Gender);

                // Add the Email Id Value to database
                sqlCommand.Parameters.AddWithValue("@EmailId", registrationModel.EmailId);

                // Add the Phone Number Value to database
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", registrationModel.PhoneNumber);

                // Add the City Value to database
                sqlCommand.Parameters.AddWithValue("@City", registrationModel.City);

                // Add the Registration Date to database
                //sqlCommand.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);

                // this varibale strores the Encrypted password
                string password = this.encryptDecrypt.EncodePasswordToBase64(registrationModel.Password);

                // Add the Encrypted password to database
                sqlCommand.Parameters.AddWithValue("@Password", password);

                // Opens the Sql Connection
                this.sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    // Read the Employee Id and convert it into integer
                    responseModel.Id = Convert.ToInt32(sqlDataReader["EmployeeId"]);

                    // Read the First Name
                    responseModel.FirstName = sqlDataReader["FirstName"].ToString();

                    // Read the Last Name
                    responseModel.LastName = sqlDataReader["LastName"].ToString();

                    // Read the Email Id
                    responseModel.EmailId = sqlDataReader["EmailId"].ToString();

                    // Read the Gender
                    responseModel.Gender = sqlDataReader["Gender"].ToString();

                    // Read the Phone Number 
                    responseModel.PhoneNumber = sqlDataReader["PhoneNumber"].ToString();

                    // Read the City
                    responseModel.City = sqlDataReader["City"].ToString();

                    responseModel.Password = sqlDataReader["Password"].ToString();

                    // Read the Registration date and convert into Date Time
                    responseModel.RegistrationDate = Convert.ToDateTime(sqlDataReader["RegistrationDate"]);
                   
                    //responseModel.UpdationDate = Convert.ToDateTime(sqlDataReader["UpdationDate"]);

                    // Add all the data into Ilist
                    userModelList.Add(responseModel);
                }

                // close Sql Connection
                this.sqlConnection.Close();

                // return the Ilist
                return userModelList;
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
        public LoginResponseModel UserLogin(LoginRequestModel userLoginModel)
        {
            
            try
            {
                LoginResponseModel loginModel = new LoginResponseModel();
                // New Ilist is created to store the result 
               // IList<LoginResponseModel> userModelList = new List<LoginResponseModel>();

                // create the object of SqlCommand and send the command and connection object
                SqlCommand sqlCommand = this.StoreProcedureConnection("spUserLogin", this.sqlConnection);

                // Add the Email Id
                sqlCommand.Parameters.AddWithValue("@EmailId", userLoginModel.EmailId);
                string password = this.encryptDecrypt.EncodePasswordToBase64(userLoginModel.Password);

                // Add the Encrypted password
                sqlCommand.Parameters.AddWithValue("@Password", password);

                // Opens the Sql Connection
                this.sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                int status = 1;
               
                while (sqlDataReader.Read())
                {
                    status = sqlDataReader.GetInt32(0);

                    if (status == 0)
                    {
                        return loginModel;
                    }

                    // Read the Employee Id and convert it into integer
                    loginModel.Id = Convert.ToInt32(sqlDataReader["EmployeeId"]);

                    // Read the First Name
                    loginModel.FirstName = sqlDataReader["FirstName"].ToString();

                    // Read the Last Name
                    loginModel.LastName = sqlDataReader["LastName"].ToString();

                    // Read the Email Id
                    loginModel.EmailId = sqlDataReader["EmailId"].ToString();

                    // Read the Gender
                    loginModel.Gender = sqlDataReader["Gender"].ToString();

                    // Read the Phone Number 
                    loginModel.PhoneNumber = sqlDataReader["PhoneNumber"].ToString();

                    // Read the City
                    loginModel.City = sqlDataReader["City"].ToString();

                    // Read the Registration date and convert into Date Time
                    loginModel.RegistrationDate = Convert.ToDateTime(sqlDataReader["RegistrationDate"]);

                    loginModel.LoginTime = Convert.ToDateTime(DateTime.Now);

                    // Add all the data into Ilist
                }

                // close Sql Connection
                this.sqlConnection.Close();

                // return the Ilist
                return loginModel;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private SqlCommand StoreProcedureConnection(string procedurename, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(procedurename, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                return command;
            }
        }

        /// <summary>
        /// configuration with database
        /// </summary>
        /// <returns>return builder</returns>
        private IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
