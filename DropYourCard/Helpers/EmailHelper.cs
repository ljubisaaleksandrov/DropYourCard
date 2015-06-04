using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
using DropYourCard.Data.Models;
using DropYourCard.Enums;

namespace DropYourCard.Helpers
{
    public static class EmailHelper
    {
        public static bool SendConfirmEmail(User user, string url)
        {
            try
            {
                SmtpClient client = new SmtpClient
                {
                    EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSLOnMail"])
                };
                
                client.Send(EmailTemplateGenerator.GenerateTemplete(EmailTemplate.ConfirmRegistration, user, url));
                return true;
            }
            catch (Exception e)
            {
                // unhandled
                return false;
            }
        }

        
    }
}