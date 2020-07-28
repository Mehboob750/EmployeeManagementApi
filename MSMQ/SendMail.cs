//-----------------------------------------------------------------------
// <copyright file="SendMail.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Mehboob Shaikh</author>
//-----------------------------------------------------------------------
[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

namespace MSMQ
{
    using System;
    using System.Net.Mail;

    /// <summary>
    /// This Class Contains Method which is used For sending Mail
    /// </summary>
    public class SendMail
    {
        /// <summary>
        /// This Method is used for sending Mail
        /// </summary>
        /// <param name="email">It contains Email id</param>
        /// <param name="token">It contains JWT Token</param>
        public void ReceiveMessageFromQueue(string email, string token)
        {
            try
            {
                // it contains Url which is send in Mail
                string url = "http://localhost:44359/api/User/ResetPassword";

                // Created new instance of MailMessage
                MailMessage mail = new MailMessage();

                // It is an New instence of smtpClient
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                // It contains Sender mail Address
                mail.From = new MailAddress("bunny568203@gmail.com");

                // It Contains the Reciver mail Address
                mail.To.Add(new MailAddress("bunny568203@gmail.com"));

                // It is an Subject Of mail
                mail.Subject = "Link for Reseting Password";

                // It is an body of Mail
                mail.Body = "Click on link " + url + "\t to reset the password \n Token: " + token;

                smtpClient.Credentials = new System.Net.NetworkCredential("bunny568203@gmail.com", "9096438838");
                smtpClient.EnableSsl = true;

                // Send Mail
                smtpClient.Send(mail);
                Console.WriteLine("link has been sent to your mail!!!");
            }
            catch (Exception exception)
            {
                Console.Write(exception.ToString());
            }
        }
    }
}
