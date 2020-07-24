using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Experimental.System.Messaging;

namespace EmployeeManagement.MSMQSender
{
    public class ForgetPasswordSender
    {
        public void ForgetPasswordMessage(string email, string token)
        {
            MessageQueue messageQueue = null;

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

            try
            {
                messageQueue.Send(email, token);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
