using System;
using System.Net;
using System.Net.Mail;

namespace LearningHelper.Utility
{
    public class SendMail
    {
        public int SendOTP(string aUserEmail)
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;
            Random random = new Random();
            int randomNumber=random.Next(000000, 999999);

            string emailFromAddress = "sayedsports@gmail.com";//Sender Email Address
            string password = "85251246";//Sender Password
            string emailToAddress = aUserEmail;//Receiver Email Address
            string subject = "Confirmation Code";
            string body = "Use "+ randomNumber + " as your confirmation code.";
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }

            return randomNumber;
        }
    }
}