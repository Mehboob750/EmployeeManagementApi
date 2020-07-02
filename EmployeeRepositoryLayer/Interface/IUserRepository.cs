﻿//-----------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace EmployeeRepositoryLayer.Interface
{
    using System.Threading.Tasks;
    using EmployeeCommonLayer;

    /// <summary>
    /// Interface of User Repository Layer
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// It is an interface of User Registration Method
        /// </summary>
        /// <param name="userModel">It is an object of User Model class</param>
        /// <returns>If register successfully it returns true</returns>
        Task<bool> UserRegistration(UserModel userModel);

        /// <summary>
        ///  It is an interface of User Login Method
        /// </summary>
        /// <param name="userModel">It is an object of User Model class</param>
        /// <returns>If Login Successfully it returns true</returns>
        Task<bool> UserLogin(UserModel userModel);
    }
}
