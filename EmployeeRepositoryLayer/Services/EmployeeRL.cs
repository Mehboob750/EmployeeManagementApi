//-----------------------------------------------------------------------
// <copyright file="EmployeeRepository.cs" company="BridgeLabz Solution">
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
    using EmployeeRepositoryLayer.Interface;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// This Class is used to implement the methods of interface
    /// </summary>
    public class EmployeeRL : IEmployeeRL
    {
        SqlConnection sqlConnection ;
        public EmployeeRL()
        {
            var configuration = this.GetConfiguration();
            this.sqlConnection = new SqlConnection(configuration.GetSection("Data").GetSection("ConnectionString").Value);
        }

        /// <summary>
        /// This Method is used to add new record 
        /// </summary>
        /// <param name="employeeModel">It is an object of Employee model class</param>
        /// <returns>If record added successfully it returns true</returns>
        public async Task<bool> AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                SqlCommand sqlCommand = this.StoreProcedureConnection("spInsertRecord", this.sqlConnection);

                // Add the First Name Value to database
                sqlCommand.Parameters.AddWithValue("@FirstName", employeeModel.FirstName);

                // Add the Last Name Value to database
                sqlCommand.Parameters.AddWithValue("@LastName", employeeModel.LastName);

                // Add the Gender Value to database
                sqlCommand.Parameters.AddWithValue("@Gender", employeeModel.Gender);

                // Add the Email Id Value to database
                sqlCommand.Parameters.AddWithValue("@EmailId", employeeModel.EmailId);

                // Add the Phone Number Value to database
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", employeeModel.PhoneNumber);

                // Add the City Value to database
                sqlCommand.Parameters.AddWithValue("@City", employeeModel.City);

                // Add the Registration Date to database
                sqlCommand.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);

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
        /// This Method is used to Read all Record
        /// </summary>
        /// <returns>It returns the all record</returns>
        public IList<EmployeeModel> ReadEmployee()
        {
            try
            {
                // New Ilist is created to store the result 
                IList<EmployeeModel> employeeModelsList = new List<EmployeeModel>();

                // create the object of SqlCommand and send the command and connection object
                SqlCommand sqlCommand = this.StoreProcedureConnection("spReadRecord", this.sqlConnection);

                // Opens the Sql Connection
                this.sqlConnection.Open();

                // Read the employee data from database using SqlDataReader
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                // Data is read upto data is present 
                while (sqlDataReader.Read())
                {
                    // Create the object of Employee Model Class 
                    EmployeeModel employeeModel = new EmployeeModel();

                    // Read the Employee Id and convert it into integer
                    employeeModel.EmployeeId = Convert.ToInt32(sqlDataReader["EmployeeId"]);

                    // Read the First Name
                    employeeModel.FirstName = sqlDataReader["FirstName"].ToString();

                    // Read the Last Name
                    employeeModel.LastName = sqlDataReader["LastName"].ToString();

                    // Read the Email Id
                    employeeModel.EmailId = sqlDataReader["EmailId"].ToString();

                    // Read the Gender
                    employeeModel.Gender = sqlDataReader["Gender"].ToString();

                    // Read the Phone Number 
                    employeeModel.PhoneNumber = sqlDataReader["PhoneNumber"].ToString();

                    // Read the City
                    employeeModel.City = sqlDataReader["City"].ToString();

                    // Read the Registration date and convert into Date Time
                    employeeModel.RegistrationDate = Convert.ToDateTime(sqlDataReader["RegistrationDate"]);

                    // Add all the data into Ilist
                    employeeModelsList.Add(employeeModel);
                }

                // close Sql Connection
                this.sqlConnection.Close();

                // return the Ilist
                return employeeModelsList;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// This Method is used to Update a Record
        /// </summary>
        /// <param name="employeeModel">It contains the Object of Employee Model</param>
        /// <returns>If record updated it return true</returns>
        public async Task<bool> UpdateEmployee(int EmployeeId,EmployeeModel employeeModel)
        {
            try
            {
                // create the object of SqlCommand and send the command and connection object
                SqlCommand sqlCommand = this.StoreProcedureConnection("spUpdateRecord", this.sqlConnection);

                // Add the Employee Id Value to database
                sqlCommand.Parameters.AddWithValue("@EmployeeId", EmployeeId);

                // Add the First Name Value to database
                sqlCommand.Parameters.AddWithValue("@FirstName", employeeModel.FirstName);

                // Add the Last Name Value to database
                sqlCommand.Parameters.AddWithValue("@LastName", employeeModel.LastName);

                // Add the Gender Value to database
                sqlCommand.Parameters.AddWithValue("@Gender", employeeModel.Gender);

                // Add the Email Id Value to database
                sqlCommand.Parameters.AddWithValue("@EmailId", employeeModel.EmailId);

                // Add the Phone Number Value to database
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", employeeModel.PhoneNumber);

                // Add the City Value to database
                sqlCommand.Parameters.AddWithValue("@City", employeeModel.City);

                // Add the Updated Date to database
                sqlCommand.Parameters.AddWithValue("@UpdationDate", DateTime.Now);

                // Opens the Sql Connection
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
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        /// This Method is used to Delete the Record
        /// </summary>
        /// <param name="employeeModel">It contains the Object of Employee Model</param>
        /// <returns>If record deleted it return true</returns>
        public IList<EmployeeModel> DeleteEmployee(int EmployeeId)
        {
            try
            {
                // New Ilist is created to store the result 
                IList<EmployeeModel> employeeModelsList = new List<EmployeeModel>();

                employeeModelsList = SearchEmployee(EmployeeId);

                if (employeeModelsList.Count.Equals(1))
                {
                    // create the object of SqlCommand and send the command and connection object
                    SqlCommand sqlCommand = this.StoreProcedureConnection("spDeleteRecord", this.sqlConnection);

                    // Add the Employee Id Value 
                    sqlCommand.Parameters.AddWithValue("@EmployeeId", EmployeeId);

                    // Opens the Sql Connection
                    this.sqlConnection.Open();
                    var response = sqlCommand.ExecuteNonQueryAsync();
                }
                return employeeModelsList;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }

        /// <summary>
        ///  This Method is used to Search the Record
        /// </summary>
        /// <param name="employeeModel">It contains the Object of Employee Model</param>
        /// <returns>It returns the searched record</returns>
        public IList<EmployeeModel> SearchEmployee(int EmployeeId)
        {
            try
            {
                // New Ilist is created to store the result 
                IList<EmployeeModel> employeeModelsList = new List<EmployeeModel>();

                // create the object of SqlCommand and send the command and connection object
                SqlCommand sqlCommand = this.StoreProcedureConnection("spSearchEmployee", this.sqlConnection);

                if (EmployeeId > 0)
                {
                    // Add the Employee Id Value 
                    sqlCommand.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                   // sqlCommand.Parameters.AddWithValue("@EmailId", EmailId);
                }

                // Opens the Sql Connection
                this.sqlConnection.Open();

                // Read the employee data from database using SqlDataReader
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                EmployeeModel employeeModel = new EmployeeModel();
                // Data is read upto data is present 
                while (sqlDataReader.Read())
                {
                    // Read the Employee Id and convert it into integer
                    employeeModel.EmployeeId = Convert.ToInt32(sqlDataReader["EmployeeId"]);

                    // Read the First Name
                    employeeModel.FirstName = sqlDataReader["FirstName"].ToString();

                    // Read the Last Name
                    employeeModel.LastName = sqlDataReader["LastName"].ToString();

                    // Read the Email Id
                    employeeModel.EmailId = sqlDataReader["EmailId"].ToString();

                    // Read the Gender
                    employeeModel.Gender = sqlDataReader["Gender"].ToString();

                    // Read the Phone Number 
                    employeeModel.PhoneNumber = sqlDataReader["PhoneNumber"].ToString();

                    // Read the City
                    employeeModel.City = sqlDataReader["City"].ToString();

                    // Read the Registration date and convert into Date Time
                    employeeModel.RegistrationDate = Convert.ToDateTime(sqlDataReader["RegistrationDate"]);

                    // Add all the data into Ilist
                    employeeModelsList.Add(employeeModel);
                }

                // close Sql Connection
                this.sqlConnection.Close();

                // return the Ilist
                return employeeModelsList;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        private SqlCommand StoreProcedureConnection(string procedureName, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                return command;
            }
        }

    }
}
