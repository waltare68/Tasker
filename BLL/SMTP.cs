using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class SMTP
    {
        public static void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                
                var smtpSection = (SmtpSection)System.Configuration.ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                string fromEmail = smtpSection.From;
                string host = smtpSection.Network.Host;
                int port = smtpSection.Network.Port;
                string username = smtpSection.Network.UserName;
                string password = smtpSection.Network.Password;
                bool enableSsl = smtpSection.Network.EnableSsl;

               
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(new MailAddress(toEmail));

               
                using (var smtpClient = new SmtpClient(host, port))
                {
                    smtpClient.Credentials = new NetworkCredential(username, password);
                    smtpClient.EnableSsl = enableSsl;

                    
                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error sending email: " + ex.Message, ex);
            }
        }
    }
}
