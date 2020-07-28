//-----------------------------------------------------------------------
// <copyright file="TokenGenerator.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace EmployeeRepositoryLayer.Services.Token
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using EmployeeCommonLayer.ResponseModel;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    /// <summary>
    /// This class Used For Token Generation
    /// </summary>
    public class TokenGenerator
    {
        /// <summary>
        /// Created the refference of IConfiguration
        /// </summary>
        IConfiguration configuration;

        /// <summary>
        /// Parametrized Constructor
        /// </summary>
        /// <param name="configuration">It contains the configurations</param>
        public TokenGenerator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// This Method is used generate Token
        /// </summary>
        /// <param name="responseModel">It is an Object of Registration Response Model</param>
        /// <returns>It returns JWT Token</returns>
        public string CreateToken(RegistrationResponseModel responseModel)
        {
            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim("EmailId", responseModel.EmailId.ToString()));
                claims.Add(new Claim("Id", responseModel.Id.ToString()));
                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCreds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}