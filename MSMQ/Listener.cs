using System;
using Experimental.System.Messaging;

namespace MSMQ
{
    public class Listener
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Message");

            MessageQueue messageQueue;
            messageQueue = new MessageQueue(@".\Private$\messageQueue");

            Message message = messageQueue.Receive();
            message.Formatter = new BinaryMessageFormatter();

            Console.WriteLine(message.Body.ToString());
            Console.ReadLine();
        }
    }
}
