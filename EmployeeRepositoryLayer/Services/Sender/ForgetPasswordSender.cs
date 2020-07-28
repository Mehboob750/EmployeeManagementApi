//-----------------------------------------------------------------------
// <copyright file="ForgetPasswordSender.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace EmployeeManagement.MSMQSender
{
    using System;
    using Experimental.System.Messaging;

    /// <summary>
    /// This Class contains method to send message 
    /// </summary>
    public class ForgetPasswordSender
    {
        /// <summary>
        /// This method is used to send message
        /// </summary>
        /// <param name="email">It contains Email</param>
        /// <param name="token">It contains Token</param>
        public void ForgetPasswordMessage(string email, string token)
        {
            try
            {
                // Created the referrence of MessageQueue
                MessageQueue messageQueue = null;

                // Check if Message Queue Exists
                if (MessageQueue.Exists(@".\Private$\ForgetQueue"))
                {
                    messageQueue = new MessageQueue(@".\Private$\ForgetQueue");
                    messageQueue.Label = "Testing Queue";
                }
                else
                {
                    MessageQueue.Create(@".\Private$\ForgetQueue");
                    messageQueue = new MessageQueue(@".\Private$\ForgetQueue");
                    messageQueue.Label = "Newly Created Queue";
                }

                // Message send to Queue
                messageQueue.Send(email, token);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
