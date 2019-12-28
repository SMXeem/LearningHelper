using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using LearningHelper.Models;

namespace LearningHelper.Manager
{
    public class SendMail
    {
        

        public int SendOTP(string aUserEmail)
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;
            Random random = new Random();
            int RNumber=random.Next(000000, 999999);

            string emailFromAddress = "sayedsports@gmail.com";//Sender Email Location
            string password = "85251246";//Sender Password
            string emailToAddress = aUserEmail;//Receiver Email Location
            string subject = "Confirmation Code";
            string body = "Use "+RNumber+" as your confirmation code.";
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

            return RNumber;
        }
    }
}