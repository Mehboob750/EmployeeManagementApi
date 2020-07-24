using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace MSMQ
{
    public class SMTP
    {
        public void SendMail(string data)
        {
            try
            {
                // variable declare for mail
                var mail = new MimeMessage();

                // mail sender
                mail.From.Add(address: new MailboxAddress("Employee Management", "bunny568203@gmail.com"));

                // messsage reciever
                mail.To.Add(new MailboxAddress("Employee Management", "bunny568203@gmail.com"));

                // subject of email
                mail.Subject = "Registration";

                // body of email
                mail.Body = new TextPart("plain")
                {
                    Text = data
                };

                //Connection 
                //Authentication
                //sending email
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587);
                    client.Authenticate("bunny568203@gmail.com", "9096438838");
                    client.Send(mail);
                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
