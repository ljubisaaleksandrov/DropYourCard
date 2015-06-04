using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using DropYourCard.Data.Models;
using DropYourCard.Enums;

namespace DropYourCard.Helpers
{
    public static class EmailTemplateGenerator
    {
        /// <summary>
        /// Generates an email body accordingly to the email template number
        /// </summary>
        /// <param name="emailTemplate">Chosen value from EmailTempate Enum</param>
        /// <param name="receiver">User receiver</param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static MailMessage GenerateTemplete(EmailTemplate emailTemplate, User receiver, string url = "")
        {
            MailMessage message = new MailMessage(
                    new MailAddress("bravoteamserbia@gmail.com"),
                    new MailAddress(receiver.Email));
                
            switch (emailTemplate)
            {
                case EmailTemplate.ConfirmRegistration:
                    {
                        message.Subject = "Email confirmation";
                        message.Body = string.Format(
                            "Dear <strong>{0}</strong>,<br/><br/>Thank you for your registration, please click on the below link to comlete your registration: <a href=\"{1}\" title=\"User Email Confirm\">{1}</a>",
                            receiver.UserName, url);
                        message.IsBodyHtml = true;
                        break;
                    }
                default:
                    {
                        // Treba da se izmeni ovo handlovanje da se ubace i logovi ili snima u bazi
                        throw new Exception(string.Format("Email Template: {0} does not exist! Receiver: {1}", emailTemplate, receiver.UserName));
                        break;
                    }
            }

            return message;
        }
    }
}