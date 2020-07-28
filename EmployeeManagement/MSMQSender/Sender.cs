//-----------------------------------------------------------------------
// <copyright file="Sender.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace EmployeeManagement.Sender
{
    using Experimental.System.Messaging;

    /// <summary>
    /// This class contains method to send MSMQ message 
    /// </summary>
    public class Sender
    {
        /// <summary>
        /// This method is used to send message to Queue 
        /// </summary>
        /// <param name="SendMessage">It contains the message to be send</param>
        public void Message(string SendMessage)
        {
            MessageQueue messageQueue;

            if (MessageQueue.Exists(@".\Private$\messageQueue"))
            {
                messageQueue = new MessageQueue(@".\Private$\messageQueue");
            }
            else
            {
                messageQueue = MessageQueue.Create(@".\Private$\messageQueue");
            }

            // Message
            Message message = new Message();

            // Message in Binary formate
            message.Formatter = new BinaryMessageFormatter();

            // Message body
            message.Body = SendMessage;

            // Message lable
            message.Label = "UserRegistration";

            // Message fetched on the basis of priority
            message.Priority = MessagePriority.Normal;

            // Message send to the Queue
            messageQueue.Send(message);
        }
    }
}
