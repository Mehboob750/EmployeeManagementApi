using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace MSMQ
{
    public class Receiver
    {
        public void ReceiveMessageFromQueue(string email, string token)
        {
            try
            {
                string url = "http://localhost:44359/api/User/ResetPassword";

                MailMessage mail = new MailMessage();

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                mail.From = new MailAddress("bunny568203@gmail.com");
                mail.To.Add(new MailAddress("bunny568203@gmail.com"));
                mail.Subject = "Link for Reseting Password";
                mail.Body = "Click on link " + url + "\t to reset the password \n Token: " + token ;

                smtpClient.Credentials = new System.Net.NetworkCredential("bunny568203@gmail.com", "9096438838");
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);
                Console.WriteLine("link has been sent to your mail!!!");
            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
            }
            Console.WriteLine("Message received ...");
        }
    }
}
