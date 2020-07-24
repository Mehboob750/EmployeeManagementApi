using System;
using Experimental.System.Messaging;

namespace MSMQ
{
    public class Listener
    {
        public static void Main(string[] args)
        {
            SMTP smtp = new SMTP();

            Console.WriteLine("Message");

            MessageQueue messageQueue;
            messageQueue = new MessageQueue(@".\Private$\messageQueue");

            Message message = messageQueue.Receive();
            message.Formatter = new BinaryMessageFormatter();
            
            //Mail send 
            //smtp.SendMail(message.Body.ToString());

            Console.WriteLine(message.Body.ToString());
            Console.ReadLine();
        }
    }
}
