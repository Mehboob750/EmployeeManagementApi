using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Experimental.System.Messaging;

namespace EmployeeManagement.Sender
{
    public class Sender
    {
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

            //Message
            Message message = new Message();

            //Message in Binary formate
            message.Formatter = new BinaryMessageFormatter();

            //Message body
            message.Body = SendMessage;

            //Message lable
            message.Label = "UserRegistration";

            //Message fetched on the basis of priority
            message.Priority = MessagePriority.Normal;

            //Message send to the Queue
            messageQueue.Send(message);
        }
    }
}
